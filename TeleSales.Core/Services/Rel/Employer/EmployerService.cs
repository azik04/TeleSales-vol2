using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Interfaces.Rel.Employer;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Services.Rel.Employer;

public class EmployerService : IEmployerService
{
    private readonly ApplicationDbContext _db;
    public EmployerService(ApplicationDbContext db)
    {
        _db = db; 
    }
    public async Task<BaseResponse<GetEmployerDto>> CreateAsync(CreateUpdateEmployerDto dto)
    {
        var data = new Employers
        {
            CreateAt = DateTime.Now,
            DepartmentId = dto.DepartmentId,
            FullName = dto.FullName,
            Position = dto.Position,
            Email = dto.Email,
        };

        await _db.Employers.AddAsync(data);
        await _db.SaveChangesAsync();

        var vm = new GetEmployerDto
        {
            DepartmentId = data.DepartmentId,
            Email = data.Email,
            FullName = data.FullName,
            Position = data.Position,
            Id =data.id
        };

        return new BaseResponse<GetEmployerDto>(vm, true);
    }

    public async Task<BaseResponse<PagedResponse<GetEmployerDto>>> GetAllByDepartment(int pageNumber, int pageSize, long departmentId)
    {
        var data = await _db.Employers
           .Where(x => !x.isDeleted && x.DepartmentId == departmentId)
           .Include(x => x.Department)
           .Skip((pageNumber - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();


        var totalCount = await _db.Employers
           .Where(x => !x.isDeleted && x.DepartmentId == departmentId)
           .CountAsync();

        var dataDtos = data.Select(a => new GetEmployerDto
        {
            Id = a.id,
            FullName = a.FullName,
            DepartmentId = a.DepartmentId,
            DepartmentName = a.Department.Name,
            Email = a.Email,
            Position = a.Position,
        }).ToList();


        var pagedResult = new PagedResponse<GetEmployerDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };

        return new BaseResponse<PagedResponse<GetEmployerDto>>(pagedResult);

    }

    public async Task<BaseResponse<GetEmployerDto>> RemoveAsync(long id)
    {
        var data = await _db.Employers.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);
        data.isDeleted = true;

        _db.Employers.Update(data);
        await _db.SaveChangesAsync();

        var vm = new GetEmployerDto
        {
            DepartmentId = data.DepartmentId,
            Email = data.Email,
            FullName = data.FullName,
            Position = data.Position,
            Id = data.id
        };
        return new BaseResponse<GetEmployerDto>(vm, true);

    }
}
