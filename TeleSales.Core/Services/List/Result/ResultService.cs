using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.List.Result;
using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Interfaces.List.Result;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.Result;

public class ResultService : IResultService
{
    private readonly ApplicationDbContext _db;
    public ResultService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<BaseResponse<GetResultDto>> CreateAsync(CreateResultDto dto)
    {
        var data = new Results
        {
            Name = dto.Name,
        };

        await _db.Results.AddAsync(data);
        await _db.SaveChangesAsync();
        
        var dtos = new GetResultDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = DateTime.Now,
        };

        return new BaseResponse<GetResultDto>(dtos, true);
    }


    public async Task<BaseResponse<ICollection<GetResultDto>>> GetAllAsync()
    {
        var data = await _db.Results.Where(x => !x.isDeleted).ToListAsync();

        var dataDtos = data.Select(a => new GetResultDto
        {
            Id = a.id,
            Name = a.Name,
            IsDeleted = a.isDeleted,
            CreateAt = a.CreateAt,
        }).ToList();

        return new BaseResponse<ICollection<GetResultDto>>(dataDtos, true);
    }

    public async Task<BaseResponse<GetResultDto>> RemoveAsync(long id)
    {
        var data = await _db.Results.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);
 
        if (data == null)
            return new BaseResponse<GetResultDto>(null, false);

        data.isDeleted = true;

        _db.Results.Update(data);
        await _db.SaveChangesAsync();

        var dtos = new GetResultDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        return new BaseResponse<GetResultDto>(dtos, true);
    }
}
