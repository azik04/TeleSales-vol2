using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Interfaces.List.Region;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.Region;

public class RegionService : IRegionService
{
    private readonly ApplicationDbContext _db;
    public RegionService(ApplicationDbContext db)
    {
        _db = db; 
    }
    public async Task<BaseResponse<GetRegionDto>> CreateAsync(CreateRegionDto model)
    {
        var data = new Regions
        {
            Name = model.Name,
            CityId = model.CityId,
        };

        await _db.Regions.AddAsync(data);
        await _db.SaveChangesAsync();

        var dtos = new GetRegionDto
        {
            Id = data.id,
            Name = data.Name,
            CityId = data.CityId,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        return new BaseResponse<GetRegionDto>(dtos, true);
    }

    public async Task<BaseResponse<ICollection<GetRegionDto>>> GetAllAsync()
    {
        var data = await _db.Regions.Where(x => !x.isDeleted).ToListAsync();

        var dataDtos = data.Select(a => new GetRegionDto
        {
            Id = a.id,
            Name = a.Name,
            CityId=a.CityId,
            IsDeleted = a.isDeleted,
            CreateAt = a.CreateAt,
        }).ToList();

        return new BaseResponse<ICollection<GetRegionDto>>(dataDtos, true);
    }

    public async Task<BaseResponse<GetRegionDto>> RemoveAsync(long id)
    {
        var data = await _db.Regions.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);
        
        if (data == null)
            return new BaseResponse<GetRegionDto>(null, false);

        data.isDeleted = true;

        _db.Regions.Update(data);
        await _db.SaveChangesAsync();

        var dtos = new GetRegionDto
        {
            Id = data.id,
            Name = data.Name,
            CityId = data.CityId,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        return new BaseResponse<GetRegionDto>(dtos, true);
    }
}
