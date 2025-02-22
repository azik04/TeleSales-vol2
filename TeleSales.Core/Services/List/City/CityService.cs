using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using TeleSales.Core.Dto.List.City;
using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Interfaces.List.City;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.City;

public class CityService : ICityService
{
    private readonly ApplicationDbContext _db;
    public  CityService(ApplicationDbContext db)
    {
        _db = db; 
    }

    public async Task<BaseResponse<GetCityDto>> CreateAsync(CreateCityDto dto)
    {
        var city = new Cities
        {
            CreateAt = DateTime.Now,
            Name = dto.Name,
        };

        await _db.Cities.AddAsync(city);
        await _db.SaveChangesAsync();

        var dtos = new GetCityDto
        {
            Id = city.id,
            CreateAt = city.CreateAt,
            Name = city.Name,
            IsDeleted = city.isDeleted
        };

        return new BaseResponse<GetCityDto>(dtos);
    }


    public async Task<BaseResponse<ICollection<GetCityDto>>> GetAllWithRegionsAsync()
    {
        var cities =  _db.Cities
            .Where(x => !x.isDeleted)
            .Select(city => new GetCityDto
            {
                Id = city.id,
                Name = city.Name,
                IsDeleted = city.isDeleted,
                CreateAt = city.CreateAt,
                Regions = _db.Regions
                    .Where(region => region.CityId == city.id)
                    .Select(region => new GetRegionDto
                    {
                        Id = region.id,
                        Name = region.Name
                    })
                    .ToList()
            })
            .ToList();

        return new BaseResponse<ICollection<GetCityDto>>(cities);
    }


    public async Task<BaseResponse<GetCityDto>> RemoveAsync(long id)
    {
        var city = _db.Cities.SingleOrDefault(x => x.id == id);
        city.isDeleted = true;

        _db.Cities.Update(city);
        await _db.SaveChangesAsync();

        var dtos = new GetCityDto
        {
            Id = city.id,
            CreateAt = city.CreateAt,
            Name = city.Name,
            IsDeleted = city.isDeleted
        };

        return new BaseResponse<GetCityDto>(dtos);
    }
}
