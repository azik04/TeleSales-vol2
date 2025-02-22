using AutoMapper;
using EFCore.BulkExtensions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Channels;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Dto.Main.Uzadilma;
using TeleSales.Core.Helpers.Excell.DebitorExcellHelper;
using TeleSales.Core.Interfaces.Main.Debitor;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;
using TeleSales.DataProvider.Enums;

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


    public async Task<FileResponse<bool>> ImportFromExcelAsync(Stream excelFileStream, long channelId)
    {
        var channel = await _db.Сhannels.FindAsync(channelId);

        if (channel == null || channel.Type != ChannelType.Debitor)
            return new FileResponse<bool>(false, false);

        var response = await _import.ImportFromExcelAsync(excelFileStream, channelId);

        if (!response.Success)
            return new FileResponse<bool>(false, false, response.Message, response.ErrorFileBytes); 

        var callsList = response.Data;

        if (callsList == null || !callsList.Any())
            return new FileResponse<bool>(false, false, "No valid data found to import.");

        await _db.BulkInsertAsync(callsList); 

        if (response.ErrorFileBytes != null)
        {
            return new FileResponse<bool>(true, true, "Data successfully imported, but some errors occurred.", response.ErrorFileBytes);
        }

        return new FileResponse<bool>(true, true, "Data successfully imported from Excel.");
    }


    public async Task<BaseResponse<byte[]>> ExportToExcelAsync(long channelId)
    {
        var channel = await _db.Сhannels.FindAsync(channelId);

        if (channel == null || channel.Type != ChannelType.Debitor)
            return new BaseResponse<byte[]>(null, false);

        var currentDateTime = DateTime.Now;

        var debitors = await _db.Debitors
            .Where(x => x.ChannelId == channelId && !x.isDeleted &&
                (x.Result != null || x.ResultId == 3 && x.NextCall.HasValue && x.NextCall.Value > currentDateTime))
            .Include(x => x.Сhannel)
            .Include(x => x.Status)
            .Include(x => x.Result)
            .Include(x => x.User)
            .ToListAsync();

        if (!debitors.Any())
            throw new Exception("No calls found for the specified channel.");

        byte[] excelFile = await _helper.ExcellExportAsync(debitors);

        return new BaseResponse<byte[]>(excelFile, true); 
    }


    public async Task<BaseResponse<GetDebitorDto>> CreateAsync(CreateDebitorDto dto , long channelId)
    {
        var channel = await _db.Сhannels.FindAsync(channelId);

        if (channel == null || channel.Type != ChannelType.Debitor)
            return new BaseResponse<GetDebitorDto>(null, false);

        var call = _mapper.Map<Debitors>(dto);

        await _db.Debitors.AddAsync(call);
        await _db.SaveChangesAsync();

        var newCall = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(newCall);
    }


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllNotExcludedAsync(long channelId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ChannelId == channelId && !x.isDeleted && !x.isDone)
            .Include(x => x.Сhannel)
            .Include(x => x.Status)
            .Include(x => x.Result)
            .Include(x => x.User)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ChannelId == channelId && !x.isDeleted && !x.isDone);

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


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllExcludedAsync(long channelId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ChannelId == channelId && !x.isDeleted && x.isDone)
            .Include(x => x.Сhannel)
            .Include(x => x.Status)
            .Include(x => x.Result)
            .Include(x => x.User)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ChannelId == channelId && !x.isDeleted && !x.isDone);

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


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllByUserAsync(long userId, long channelId, int pageNumber, int pageSize)
    {
        var calls = await _db.Debitors
            .Where(x => x.ExcludedBy == userId && !x.isDeleted && x.ChannelId == channelId && !x.isDone)
            .Include(x => x.Сhannel)
            .Include(x => x.Status)
            .Include(x => x.Result)
            .Include(x => x.User)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _db.Debitors.CountAsync(x => x.ExcludedBy == userId && !x.isDeleted && x.ChannelId == channelId && !x.isDone);

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


    public async Task<BaseResponse<GetDebitorDto>> GetByIdAsync(long id)
    {
        if (id == 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id cant be 0.");

        var call = await _db.Debitors.FirstOrDefaultAsync(x => x.id == id && !x.isDeleted );

        if (call == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Call cant be NULL.");

        var callDtos = _mapper.Map<GetDebitorDto>(call);

        return new BaseResponse<GetDebitorDto>(callDtos);
    }


    public async Task<BaseResponse<ICollection<GetDebitorDto>>> GetRandomDebitorAsync(long channelId, long userId)
    {
        const string cacheKey = "RandomCalls";

        if (_memoryCache.TryGetValue(cacheKey, out ICollection<GetDebitorDto> cachedCalls) && cachedCalls.Any())
            return new BaseResponse<ICollection<GetDebitorDto>>(cachedCalls);

        DateTime thresholdDate = DateTime.Now;

        var prioritizedCall = await _db.Debitors
            .Where(x => !x.isDeleted && !x.isDone && x.ChannelId == channelId && x.ExcludedBy == userId && x.ResultId == 5
                && (x.NextCall <= thresholdDate))
            .Include(x => x.Сhannel)
            .Include(x => x.Status)
            .Include(x => x.Result)
            .Include(x => x.User)
            .FirstOrDefaultAsync();

        if (prioritizedCall != null)
        {
            cachedCalls = new List<GetDebitorDto> { _mapper.Map<GetDebitorDto>(prioritizedCall) };

            _memoryCache.Set(cacheKey, cachedCalls, new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove 
            });

            return new BaseResponse<ICollection<GetDebitorDto>>(cachedCalls);
        }

        var fallbackCalls = await _db.Debitors
            .Where(x => !x.isDeleted && !x.isDone && !x.isExcluding &&
                        x.ChannelId == channelId)
            .ToListAsync();

        if (!fallbackCalls.Any())
            return new BaseResponse<ICollection<GetDebitorDto>>(null, false, "No eligible calls available.");

        var groupedByVoen = fallbackCalls.GroupBy(x => x.VOEN).ToList();
        var randomVoenGroup = groupedByVoen.OrderBy(_ => Guid.NewGuid()).FirstOrDefault(); 

        foreach (var item in randomVoenGroup)
            item.isExcluding = true;

        await _db.SaveChangesAsync();

        cachedCalls = _mapper.Map<List<GetDebitorDto>>(randomVoenGroup);
        _memoryCache.Set(cacheKey, cachedCalls, new MemoryCacheEntryOptions
        {
            Priority = CacheItemPriority.NeverRemove 
        });

        return new BaseResponse<ICollection<GetDebitorDto>>(cachedCalls);
    }



    public async Task<BaseResponse<GetDebitorDto>> RemoveAsync(long id)
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


    public async Task<BaseResponse<GetDebitorDto>> UpdateAsync(long id, UpdateDebitorDto dto)
    {
        if (id <= 0)
            return new BaseResponse<GetDebitorDto>(null, false, "Id can't be 0.");

        var debitor = await _db.Debitors.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (debitor == null)
            return new BaseResponse<GetDebitorDto>(null, false, "Debitor not found.");

        _mapper.Map(dto, debitor);

        _db.Debitors.Update(debitor);
        await _db.SaveChangesAsync();

        var newDebitor = _mapper.Map<GetDebitorDto>(debitor);

        return new BaseResponse<GetDebitorDto>(newDebitor);
    }



    public async Task<BaseResponse<GetDebitorDto>> ExcludeAsync(long id, ExcludeDebitorDto dto)
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
        call.isDone = call.ResultId != 11;
        call.Note = dto.Note;
        call.SubResultId = dto.SubResultId;
        call.isExcluding = false;
      

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


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> SearchAsync(long channelId, SearchDebitorDto dto, int pageNumber, int pageSize)
    {
        var predicate = PredicateBuilder.New<Debitors>(x => x.ChannelId == channelId);

        if (dto.InvoiceNumber.HasValue)
            predicate = predicate.And(x => x.InvoiceNumber == dto.InvoiceNumber.Value);

        if (!string.IsNullOrEmpty(dto.VOEN))
            predicate = predicate.And(x => x.VOEN.Contains(dto.VOEN));

        if (!string.IsNullOrEmpty(dto.Subject))
            predicate = predicate.And(x => x.Subject.Contains(dto.Subject));

        if (!string.IsNullOrEmpty(dto.LegalName))
            predicate = predicate.And(x => x.LegalName.Contains(dto.LegalName));

        var totalCount = await _db.Debitors.AsExpandable().Where(predicate).CountAsync();

        var debitors = await _db.Debitors.AsExpandable() 
            .Where(predicate)
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToListAsync();

        var callDtos = _mapper.Map<List<GetDebitorDto>>(debitors);

        var pagedResult = new PagedResponse<GetDebitorDto>
        {
            Items = callDtos,
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
        };

        return new BaseResponse<PagedResponse<GetDebitorDto>>(pagedResult);
    }


    public async Task<BaseResponse<PagedResponse<GetDebitorDto>>> SearchByUserAsync(long channelId, long userId, SearchDebitorDto dto, int pageNumber, int pageSize)
    {
        var predicate = PredicateBuilder.New<Debitors>(x => x.ChannelId == channelId && x.ExcludedBy == userId);

        if (dto.InvoiceNumber.HasValue)
            predicate = predicate.And(x => x.InvoiceNumber == dto.InvoiceNumber.Value);

        if (!string.IsNullOrEmpty(dto.VOEN))
            predicate = predicate.And(x => x.VOEN.Contains(dto.VOEN));

        if (!string.IsNullOrEmpty(dto.Subject))
            predicate = predicate.And(x => x.Subject.Contains(dto.Subject));

        if (!string.IsNullOrEmpty(dto.LegalName))
            predicate = predicate.And(x => x.LegalName.Contains(dto.LegalName));

        var totalCount = await _db.Debitors.AsExpandable().Where(predicate).CountAsync();

        var debitors = await _db.Debitors.AsExpandable()
            .Where(predicate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var callDtos = _mapper.Map<List<GetDebitorDto>>(debitors);

        var pagedResult = new PagedResponse<GetDebitorDto>
        {
            Items = callDtos,
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
        };

        return new BaseResponse<PagedResponse<GetDebitorDto>>(pagedResult);
    }
}
