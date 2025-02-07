using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Interfaces.List.ApplicationType;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Services.List.ApplicationType;

public class ApplicationTypeService : IApplicationTypeService
{
    private readonly ApplicationDbContext _db;
    public ApplicationTypeService(ApplicationDbContext db)
    {
        _db = db; 
    }

    public async Task<BaseResponse<ApplicationTypes>> CreateAsync(ApplicationTypes model)
    {
        var data = new ApplicationTypes
        {
            Name = model.Name,
        };

        await _db.ApplicationTypes.AddAsync(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<ApplicationTypes>(data, true);
    }

    public async Task<BaseResponse<ICollection<ApplicationTypes>>> GetAllAsync()
    {
        var data = await _db.ApplicationTypes.Where(x => !x.isDeleted).ToListAsync();

        return new BaseResponse<ICollection<ApplicationTypes>>(data, true );
    }

    public async Task<BaseResponse<ApplicationTypes>> RemoveAsync(long id)
    {
        var data = await _db.ApplicationTypes.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        data.isDeleted = true;
        
        _db.ApplicationTypes.Update(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<ApplicationTypes>(data, true );
    }
}
