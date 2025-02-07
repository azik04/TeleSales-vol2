using Microsoft.EntityFrameworkCore;
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
    public async Task<BaseResponse<Results>> CreateAsync(Results model)
    {
        var data = new Results
        {
            Name = model.Name,
        };

        await _db.Results.AddAsync(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Results>(data, true);
    }

    public async Task<BaseResponse<ICollection<Results>>> GetAllAsync()
    {
        var data = await _db.Results.Where(x => !x.isDeleted).ToListAsync();

        return new BaseResponse<ICollection<Results>>(data, true);
    }

    public async Task<BaseResponse<Results>> RemoveAsync(long id)
    {
        var data = await _db.Results.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        data.isDeleted = true;

        _db.Results.Update(data);
        await _db.SaveChangesAsync();

        return new BaseResponse<Results>(data, true);
    }
}
