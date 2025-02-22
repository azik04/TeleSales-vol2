using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Rel.Administration;
using TeleSales.Core.Interfaces.Rel.Administration;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.List;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Services.Rel.Administration;

public class AdministrationService : IAdministrationService
{
    private readonly ApplicationDbContext _db;
    public AdministrationService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<BaseResponse<GetAdministrationDto>> CreateAsync(CreateAdministrationDto dto)
    {
        var data = new Administrations
        {
            Name = dto.Name,
        };

        await _db.Administrations.AddAsync(data);
        await _db.SaveChangesAsync();

        var dtos = new GetAdministrationDto
        {
            id = data.id,
            Name = data.Name
        };

        return new BaseResponse<GetAdministrationDto>(dtos, true);
    }

    public async Task<BaseResponse<ICollection<GetAdministrationDto>>> GetAllAsync()
    {
        var data = await _db.Administrations.Where(x => !x.isDeleted).ToListAsync();

        var dtos = data.Select(a => new GetAdministrationDto
        {
            id = a.id,
            Name = a.Name,
        }).ToList();

        return new BaseResponse<ICollection<GetAdministrationDto>>(dtos, true);
    }

    public async Task<BaseResponse<GetAdministrationDto>> RemoveAsync(long id)
    {
        var data = await _db.Administrations.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetAdministrationDto>(null, false);

        data.isDeleted = true;

        _db.Administrations.Update(data);
        await _db.SaveChangesAsync();

        var dtos = new GetAdministrationDto
        {
            id = data.id,
            Name = data.Name
        };

        return new BaseResponse<GetAdministrationDto>(dtos, true);
    }
}
