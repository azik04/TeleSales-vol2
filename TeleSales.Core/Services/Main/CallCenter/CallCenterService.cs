using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
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
    }


    public async Task<BaseResponse<GetCallCenterDto>> Create(CreateCallCenterDto dto)
    {
        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == dto.ExcludedBy);
        if (user == null)
            return new BaseResponse<GetCallCenterDto>("Invalid ExcludedBy user ID.");

        var center = _mapper.Map<CallCenters>(dto);
        
        await _db.CallCenters.AddAsync(center);
        await _db.SaveChangesAsync();

        

        var result = _mapper.Map<GetCallCenterDto>(center);

        return new BaseResponse<GetCallCenterDto>(result);
    }




    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllByUser(long userId, long kanalId, int pageNumber, int pageSize)
    {
        if (userId == 0)
            return new BaseResponse<PagedResponse<GetCallCenterDto>>(null, false, "");

        var data = await _db.CallCenters
             .Where(x => !x.isDeleted && x.ExcludedBy == userId && x.СhannelId == kanalId)
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
             .Where(x => !x.isDeleted && x.ExcludedBy == userId && x.СhannelId == kanalId)
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


    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAll(long kanalId, int pageNumber, int pageSize)
    {
        if (kanalId <= 0)
            return new BaseResponse<PagedResponse<GetCallCenterDto>>(null, false, "");

        var data = await _db.CallCenters.Where(x => x.СhannelId == kanalId && !x.isDeleted)
             .Include(x => x.Department)
             .Include(x => x.Employer)
             .Include(x => x.Administration)
             .Include(x => x.Region)
             .Include(x => x.ApplicationType)
             .Include(x => x.User)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var totalCount = await _db.CallCenters.Where(x => kanalId == x.СhannelId == !x.isDeleted).CountAsync();


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


    public async Task<BaseResponse<GetCallCenterDto>> GetById(long id)
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



    public async Task<BaseResponse<GetCallCenterDto>> Remove(long id)
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


    public async Task<BaseResponse<byte[]>> ExportToExcelAsync(long kanalId)
    {
        var callCenters = await _db.CallCenters
            .Where(x => x.СhannelId == kanalId && !x.isDeleted)
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.ApplicationType)
            .Include(x => x.User)        
            .Include(x => x.Сhannel)
            .ToListAsync();

        if (!callCenters.Any())
            throw new Exception("No calls found for the specified channel.");

        byte[] excelFile = await _helper.ExcellExportAsync(callCenters);

        return new BaseResponse<byte[]> (excelFile, true);
    }


    public async Task<BaseResponse<GetCallCenterDto>> Update(long id, UpdateCallCenterDto dto)
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