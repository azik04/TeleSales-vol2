using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Helpers.Excell.DebitorExcellHelper;
using TeleSales.Core.Interfaces.Main.Debitor;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Services.Main.Debitor;

public class DebitorService : IDebitorService
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;
    private readonly ApplicationDbContext _db;
    private readonly DebitorExportExcellHelper _helper;
    private readonly DebitorImportExcellHelper _import;

    public DebitorService(IMemoryCache memoryCache, ApplicationDbContext db, IMapper mapper, DebitorExportExcellHelper helper , DebitorImportExcellHelper import)
    {
        _memoryCache = memoryCache;
        _import = import;
        _helper = helper;
        _db = db;
        _mapper = mapper;
    }


    public async Task<BaseResponse<bool>> ImportFromExcelAsync(Stream excelFileStream, long kanalId)
    {
        var response = await _import.ImportFromExcelAsync(excelFileStream, kanalId);

        if (!response.Success)
            return new BaseResponse<bool>(false, false, response.Message);

        var callsList = response.Data;

        if (callsList == null || !callsList.Any())
            return new BaseResponse<bool>(false, false, "No valid data found to import.");
        

        await _db.BulkInsertAsync(callsList); 

        return new BaseResponse<bool>(true, true, "Data successfully imported from Excel.");
    }



    public async Task<BaseResponse<byte[]>> ExportToExcelAsync(long kanalId)
    {
        var currentDateTime = DateTime.Now;

        var debitors = await _db.Debitors
            .Where(x => x.ChannelId == kanalId && !x.isDeleted &&
                (x.Result != null || x.ResultId == 3 && x.NextCall.HasValue && x.NextCall.Value > currentDateTime))
            .ToListAsync();

        if (!debitors.Any())
            throw new Exception("No calls found for the specified channel.");

        byte[] excelFile = await _helper.ExcellExportAsync(debitors);

        return new BaseResponse<byte[]>(excelFile, true); 
    }





    public async Task<BaseResponse<GetDebitorDto>> Create(CreateDebitorDto dto)
    {
        var call = _mapper.Map<Debitors>(dto);

        await _db.Debitors.AddAsync(call);
        await _db.SaveChangesAsync();

        var newCall = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(newCall);
    }


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllNotExcluded(long kanalId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ChannelId == kanalId && !x.isDeleted && !x.isDone)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ChannelId == kanalId && !x.isDeleted && !x.isDone);

        var callDtos = _mapper.Map<List<GetDebitorDto>>(calls);

        var pagedResult = new PagedResponse<GetDebitorDto>
        {
            Items = callDtos,
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
        };

        return new BaseResponse<PagedResponse<GetDebitorDto>>(pagedResult);
    }


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllExcluded(long kanalId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ChannelId == kanalId && !x.isDeleted && x.isDone)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ChannelId == kanalId && !x.isDeleted && !x.isDone);

        var callDtos = _mapper.Map<List<GetDebitorDto>>(calls);

        var pagedResult = new PagedResponse<GetDebitorDto>
        {
            Items = callDtos,
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
        };
        return new BaseResponse<PagedResponse<GetDebitorDto>>(pagedResult);
    }


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllByUser(long userId, long kanalId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ExcludedBy == userId && !x.isDeleted && x.ChannelId == kanalId && !x.isDone)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ExcludedBy == userId && !x.isDeleted && x.ChannelId == kanalId && !x.isDone);

        var callDtos = _mapper.Map<List<GetDebitorDto>>(calls);

        var pagedResult = new PagedResponse<GetDebitorDto>
        {
            Items = callDtos,
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
        };

        return new BaseResponse<PagedResponse<GetDebitorDto>>(pagedResult);
    }


    public async Task<BaseResponse<GetDebitorDto>> GetById(long id)
    {
        if (id == 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id cant be 0.");

        var call = await _db.Debitors.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted && x.isDone);

        if (call == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Call cant be NULL.");

        var callDtos = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(callDtos);
    }


    public async Task<BaseResponse<ICollection<GetDebitorDto>>> GetRandomCallsByVoen(long kanalId)
    {
        ICollection<GetDebitorDto> cachedCalls;

        if (!_memoryCache.TryGetValue("RandomCalls", out cachedCalls) || !cachedCalls.Any())
        {
            var thresholdDate = DateTime.Now;

            var prioritizedCalls = await _db.Debitors
                .Where(x => !x.isDeleted &&
                            x.ChannelId == kanalId &&
                            (x.NextCall == null || x.NextCall <= thresholdDate))
                .ToListAsync();

            if (prioritizedCalls.Any())
            {
                var nextCallDebtor = prioritizedCalls
                    .Where(call => call.NextCall.HasValue &&
                                   call.NextCall < DateTime.Now &&
                                   call.ResultId == 5)
                    .OrderBy(call => call.NextCall)
                    .FirstOrDefault();

                if (nextCallDebtor != null)
                {
                    cachedCalls = new List<GetDebitorDto>
                {
                    _mapper.Map<GetDebitorDto>(nextCallDebtor)
                };

                    _memoryCache.Set("RandomCalls", cachedCalls);
                    return new BaseResponse<ICollection<GetDebitorDto>>(cachedCalls);
                }
            }

            var fallbackCalls = await _db.Debitors
                .Where(x => !x.isDeleted &&
                            x.ChannelId == kanalId &&
                            (x.LastStatusUpdate == null || x.LastStatusUpdate <= thresholdDate))
                .ToListAsync();

            if (!fallbackCalls.Any())
                return new BaseResponse<ICollection<GetDebitorDto>>(null, false, "No eligible calls available.");

            var groupedByVoen = fallbackCalls.GroupBy(x => x.VOEN).ToList();
            var random = new Random();
            var randomVoenGroup = groupedByVoen.OrderBy(_ => random.Next()).FirstOrDefault();

            if (randomVoenGroup == null)
                return new BaseResponse<ICollection<GetDebitorDto>>(null, false, "No calls found for the selected VOEN.");

            cachedCalls = _mapper.Map<List<GetDebitorDto>>(randomVoenGroup.ToList());
            _memoryCache.Set("RandomCalls", cachedCalls);
        }

        return new BaseResponse<ICollection<GetDebitorDto>>(cachedCalls);
    }


    public async Task<BaseResponse<GetDebitorDto>> Remove(long id)
    {
        if (id == 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id cant be 0.");

        var call = await _db.Debitors.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (call == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Call cant be NULL.");

        call.isDeleted = true;

        _db.Debitors.Update(call);
        await _db.SaveChangesAsync();

        var newCall = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(newCall);
    }


    public async Task<BaseResponse<GetDebitorDto>> Update(long id, UpdateDebitorDto dto)
    {
        if (id <= 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id can't be 0.");

        var debitor = await _db.Debitors.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (debitor == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Debitor not found.");

        _mapper.Map<Debitors>(debitor);

        _db.Debitors.Update(debitor);
        await _db.SaveChangesAsync();

        var newDebitor = _mapper.Map<GetDebitorDto>(debitor);

        return new BaseResponse<GetDebitorDto>(newDebitor);
    }



    public async Task<BaseResponse<GetDebitorDto>> Exclude(long id, ExcludeDebitorDto dto)
    {
        if (id <= 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id cant be 0.");

        var call = await _db.Debitors.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (call == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Call cant be NULL.");

        call.ExcludedBy = dto.ExcludedBy;
        call.LastStatusUpdate = DateTime.Now;
        call.ResultId = dto.ResultId;
        call.StatusId = 2;
        call.ResultId = dto.ResultId;
        call.isDone = call.ResultId == 1;
        call.Note = dto.Note;
         
        if ((dto.ResultId == 2 || dto.ResultId == 5) && string.IsNullOrEmpty(dto.Note))
            return new BaseResponse<GetDebitorDto>(null, false, "Необходимо указать причину отказа.");

        if (dto.ResultId == 5)
        {
            if (!dto.NextCall.HasValue)
                return new BaseResponse<GetDebitorDto>(null, false, "Необходимо указать дату и время повторного звонка.");
            call.NextCall = dto.NextCall.Value.AddHours(4);
        }

        _db.Debitors.Update(call);
        await _db.SaveChangesAsync();

        if (_memoryCache.TryGetValue("RandomCalls", out ICollection<GetDebitorDto> cachedCalls))
        {
            var callToRemove = cachedCalls.FirstOrDefault(c => c.Id == id);
            if (callToRemove != null)
            {
                cachedCalls.Remove(callToRemove);
            }
        }

        var newCall = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(newCall);
    }
}
