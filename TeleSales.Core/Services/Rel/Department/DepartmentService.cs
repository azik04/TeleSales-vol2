using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Rel.Department;
using TeleSales.Core.Interfaces.Rel.Department;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Services.Rel.Department;

public class DepartmentService : IDepartmentService
{
    private readonly ApplicationDbContext _db;
    public DepartmentService(ApplicationDbContext db)
    {
        _db = db; 
    }
    public async Task<BaseResponse<GetDepartmentDto>> CreateAsync(CreateUpdateDepartmentDto dto)
    {
        var data = new Departments
        {
            AdministrationId = dto.AdministrationId,
            Name = dto.Name,
            CreateAt = DateTime.Now,
        };

        _db.Departments.AddAsync(data);
        await _db.SaveChangesAsync();

        var vm = new GetDepartmentDto
        {
            AdministrationId = data.AdministrationId,
            Name = data.Name,
            Id = data.id,
        };

        return new BaseResponse<GetDepartmentDto>(vm, true);
    }

    public async Task<BaseResponse<ICollection<GetDepartmentDto>>> GetAllByAdministration(long administrationId)
    {
        var data = await _db.Departments.Where(x => x.AdministrationId == administrationId && !x.isDeleted).Include(x => x.Administration).ToListAsync();

        var dtos = data.Select(a => new GetDepartmentDto
        {
            Id = a.id,
            Name = a.Name,
            AdministrationId = a.AdministrationId,
            AdministrationName = a.Administration.Name
        }).ToList();

        return new BaseResponse<ICollection<GetDepartmentDto>>(dtos, true);
    }


    public async Task<BaseResponse<GetDepartmentDto>> RemoveAsync(long id)
    {
        var data = await _db.Departments.SingleOrDefaultAsync(x => x.id == id) ;

        var dtos = new GetDepartmentDto
        {
            Id = data.id,
            Name = data.Name,
            AdministrationId = data.AdministrationId
        };

        return new BaseResponse<GetDepartmentDto>(dtos, true);
    }

}
