using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Interfaces.List.Status;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.Status;

public class StatusService : IStatusService
{
    private readonly ApplicationDbContext _db;
    public StatusService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<BaseResponse<GetStatusDto>> CreateAsync(CreateStatusDto model)
    {
        var data = new Statuses
        {
            Name = model.Name,
        };

        await _db.Status.AddAsync(data);
        await _db.SaveChangesAsync();

        var dtos = new GetStatusDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt
        };

        return new BaseResponse<GetStatusDto>(dtos, true); 
    }

    public async Task<BaseResponse<ICollection<GetStatusDto>>> GetAllAsync()
    {
        var data = await _db.Status.Where(x => !x.isDeleted).ToListAsync();

        var dataDtos = data.Select(a => new GetStatusDto
        {
            Id = a.id,
            Name = a.Name,
            IsDeleted = a.isDeleted,
            CreateAt = a.CreateAt,
        }).ToList();

        return new BaseResponse<ICollection<GetStatusDto>>(dataDtos, true);
    }

    public async Task<BaseResponse<GetStatusDto>> RemoveAsync(long id)
    {
        var data = await _db.Status.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetStatusDto>(null, false);

        data.isDeleted = true;

        var dtos = new GetStatusDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        _db.Status.Update(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<GetStatusDto>(dtos, true);
    }
}
