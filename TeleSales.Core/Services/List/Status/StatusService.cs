using Microsoft.EntityFrameworkCore;
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
    public async Task<BaseResponse<Statuses>> CreateAsync(Statuses model)
    {
        var data = new Statuses
        {
            Name = model.Name,
        };

        await _db.Status.AddAsync(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Statuses>(data, true);
    }

    public async Task<BaseResponse<ICollection<Statuses>>> GetAllAsync()
    {
        var data = await _db.Status.Where(x => !x.isDeleted).ToListAsync();

        return new BaseResponse<ICollection<Statuses>>(data, true);
    }

    public async Task<BaseResponse<Statuses>> RemoveAsync(long id)
    {
        var data = await _db.Status.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        data.isDeleted = true;

        _db.Status.Update(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Statuses>(data, true);
    }
}
