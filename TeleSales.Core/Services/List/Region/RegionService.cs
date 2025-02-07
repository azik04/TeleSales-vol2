using Microsoft.EntityFrameworkCore;
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
    public async Task<BaseResponse<Regions>> CreateAsync(Regions model)
    {
        var data = new Regions
        {
            Name = model.Name,
        };

        await _db.Regions.AddAsync(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Regions>(data, true);
    }

    public async Task<BaseResponse<ICollection<Regions>>> GetAllAsync()
    {
        var data = await _db.Regions.Where(x => !x.isDeleted).ToListAsync();

        return new BaseResponse<ICollection<Regions>>(data, true);
    }

    public async Task<BaseResponse<Regions>> RemoveAsync(long id)
    {
        var data = await _db.Regions.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        data.isDeleted = true;

        _db.Regions.Update(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Regions>(data, true);
    }
}
