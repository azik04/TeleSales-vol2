using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.List.ApplicationType;
using TeleSales.Core.Dto.List.Region;
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

    public async Task<BaseResponse<GetApplicationTypeDto>> CreateAsync(CreateApplicationTypeDto model)
    {
        var data = new ApplicationTypes
        {
            Name = model.Name,
        };

        await _db.ApplicationTypes.AddAsync(data);
        await _db.SaveChangesAsync();

        var dtos = new GetApplicationTypeDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        return new BaseResponse<GetApplicationTypeDto>(dtos, true);
    }

    public async Task<BaseResponse<ICollection<GetApplicationTypeDto>>> GetAllAsync()
    {
        var data = await _db.ApplicationTypes.Where(x => !x.isDeleted).ToListAsync();

        var dataDtos = data.Select(a => new GetApplicationTypeDto
        {
            Id = a.id,
            Name = a.Name,
            IsDeleted = a.isDeleted,
            CreateAt = a.CreateAt,
        }).ToList();

        return new BaseResponse<ICollection<GetApplicationTypeDto>>(dataDtos, true );
    }

    public async Task<BaseResponse<GetApplicationTypeDto>> RemoveAsync(long id)
    {
        var data = await _db.ApplicationTypes.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetApplicationTypeDto>(null, false);

        data.isDeleted = true;
        
        _db.ApplicationTypes.Update(data);
        await _db.SaveChangesAsync();

        var dtos = new GetApplicationTypeDto
        {
            Id = data.id,
            Name = data.Name,
            IsDeleted = data.isDeleted,
            CreateAt = data.CreateAt,
        };

        return new BaseResponse<GetApplicationTypeDto>(dtos, true );
    }
}
