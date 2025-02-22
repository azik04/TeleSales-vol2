using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.List.SubResult;
using TeleSales.Core.Interfaces.List.SubResult;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.SubResult;

public class SubResultService : ISubResultService
{
    private readonly ApplicationDbContext _db;
    public SubResultService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<BaseResponse<GetSubResultDto>> CreateAsync(CreateSubResultDto model)
    {
        var data = new SubResults
        {
            Name = model.Name,
            ResultId = model.ResultId,
        };

        await _db.SubResults.AddAsync(data);
        await _db.SaveChangesAsync();

        var dtos = new GetSubResultDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
            ResultId = data.ResultId,

        };

        return new BaseResponse<GetSubResultDto>(dtos, true);
    }

    public async Task<BaseResponse<ICollection<GetSubResultDto>>> GetAllAsync(long resultId)
    {
        var data = await _db.SubResults.Where(x => !x.isDeleted && x.ResultId == resultId).ToListAsync();

        var dataDtos = data.Select(a => new GetSubResultDto
        {
            Id = a.id,
            Name = a.Name,
            IsDeleted = a.isDeleted,
            CreateAt = a.CreateAt,
            ResultId = a.ResultId,
        }).ToList();

        return new BaseResponse<ICollection<GetSubResultDto>>(dataDtos, true);
    }

    public async Task<BaseResponse<GetSubResultDto>> RemoveAsync(long id)
    {
        var data = await _db.SubResults.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if(data == null)
            return new BaseResponse<GetSubResultDto>(null, false);

        data.isDeleted = true;

        _db.SubResults.Update(data);
        await _db.SaveChangesAsync();

        var dtos = new GetSubResultDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
            ResultId = data.ResultId,
        };

        return new BaseResponse<GetSubResultDto>(dtos, true);
    }
}
