using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.Core.Helpers.Excell.CallCenterExcellHelper;
using TeleSales.Core.Interfaces.Main.CallCenter;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;
 
namespace TeleSales.Core.Services.Main.CallCenter;

public class CallCenterService : ICallCenterService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly CallCenterExportExcellHelper _helper;
    public CallCenterService(ApplicationDbContext db , IMapper mapper , CallCenterExportExcellHelper helper)
    {
        _mapper = mapper;
        _helper = helper;
        _db = db;
    }


    public async Task<BaseResponse<GetCallCenterDto>> CreateAsync(CreateCallCenterDto dto, long channelId)
    {
        var channel = await _db.CallCenters.FindAsync(channelId);

        if (channel == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "ExcludedBy cannot be 0.");

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == dto.ExcludedBy && !x.isDeleted);

        if (user == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "User not found with the given ExcludedBy ID.");

        var callCenter = _mapper.Map<CallCenters>(dto);
        _db.CallCenters.Add(callCenter);
        await _db.SaveChangesAsync();

        var responseDto = _mapper.Map<GetCallCenterDto>(callCenter);

        return new BaseResponse<GetCallCenterDto>(responseDto);
    }





    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllByUserAsync(long userId, long channelId, int pageNumber, int pageSize)
    {
        var data = await _db.CallCenters
             .Where(x => !x.isDeleted && x.ExcludedBy == userId && x.ChannelId == channelId)
             .Include(x => x.Department)
             .Include(x => x.Employer)
             .Include(x => x.Administration)
             .Include(x => x.Region)
             .Include(x => x.ApplicationType)
             .Include(x => x.User)  
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();

        var totalCount = await _db.CallCenters
             .Where(x => !x.isDeleted && x.ExcludedBy == userId && x.ChannelId == channelId)
             .CountAsync();

        var dataDtos = _mapper.Map<List<GetCallCenterDto>>(data);

        var pagedResult = new PagedResponse<GetCallCenterDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };

        return new BaseResponse<PagedResponse<GetCallCenterDto>>(pagedResult);
    }


    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllAsync(long channelId, int pageNumber, int pageSize)
    {
        if (channelId <= 0)
            return new BaseResponse<PagedResponse<GetCallCenterDto>>(null, false, "");

        var data = await _db.CallCenters.Where(x => x.ChannelId == channelId && !x.isDeleted)
             .Include(x => x.Department)
             .Include(x => x.Employer)
             .Include(x => x.Administration)
             .Include(x => x.Region)
             .Include(x => x.ApplicationType)
             .Include(x => x.User)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var totalCount = await _db.CallCenters.Where(x => channelId == x.ChannelId == !x.isDeleted).CountAsync();


        var dataDtos = _mapper.Map<List<GetCallCenterDto>>(data);

        var pagedResult = new PagedResponse<GetCallCenterDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };
        return new BaseResponse<PagedResponse<GetCallCenterDto>>(pagedResult);
    }


    public async Task<BaseResponse<GetCallCenterDto>> GetByIdAsync(long id)
    {
        if (id <= 0)
            return new BaseResponse<GetCallCenterDto>(null, false, "Invalid ID.");

        var data = await _db.CallCenters
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.ApplicationType)
            .Include(x => x.User) 
            .SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "Record not found.");

        var dataDto = _mapper.Map<GetCallCenterDto>(data);

        return new BaseResponse<GetCallCenterDto>(dataDto, true, "");
    }



    public async Task<BaseResponse<GetCallCenterDto>> RemoveAsync(long id)
    {
        if (id <= 0)
            return new BaseResponse<GetCallCenterDto>(null, false, "Invalid ID.");

        var data = await _db.CallCenters
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.ApplicationType)
            .Include(x => x.User)
            .SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "Record not found.");

        data.isDeleted = true;

        _db.CallCenters.Update(data);
        await _db.SaveChangesAsync();

        var dataDto = _mapper.Map<GetCallCenterDto>(data);

        return new BaseResponse<GetCallCenterDto>(dataDto, true, "CallCenter updated successfully.");
    }


    public async Task<BaseResponse<byte[]>> ExportToExcelAsync(long channelId)
    {
        var callCenters = await _db.CallCenters
            .Where(x => x.ChannelId == channelId && !x.isDeleted)
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.ApplicationType)
            .Include(x => x.User)        
            .Include(x => x.Channel)
            .ToListAsync();

        if (!callCenters.Any())
            throw new Exception("No calls found for the specified channel.");

        byte[] excelFile = await _helper.ExcellExportAsync(callCenters);

        return new BaseResponse<byte[]> (excelFile, true);
    }


    public async Task<BaseResponse<GetCallCenterDto>> UpdateAsync(long id, UpdateCallCenterDto dto)
    {
        if (id <= 0)
            return new BaseResponse<GetCallCenterDto>(null, false, "Invalid ID.");

        var data = await _db.CallCenters
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.ApplicationType)
            .Include(x => x.User)
            .SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "CallCenter not found.");

        var update = _mapper.Map<CallCenters>(data);

        _db.CallCenters.Update(data);
        await _db.SaveChangesAsync();

        var dataDto = _mapper.Map<GetCallCenterDto>(update);
        
        return new BaseResponse<GetCallCenterDto>(dataDto, true, "CallCenter updated successfully.");
    }
}