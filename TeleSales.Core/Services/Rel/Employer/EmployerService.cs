using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Helpers.Excell.EmployerExcellHelper;
using TeleSales.Core.Interfaces.Rel.Employer;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Services.Rel.Employer;

public class EmployerService : IEmployerService
{
    private readonly ApplicationDbContext _db;
    private readonly EmpoyerImportExcellHelper _import;
    public EmployerService(ApplicationDbContext db, EmpoyerImportExcellHelper import)
    {
        _db = db; 
        _import = import;
    }
    public async Task<BaseResponse<GetEmployerDto>> CreateAsync(CreateUpdateEmployerDto dto )
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

    public async Task<BaseResponse<ICollection<GetEmployerDto>>> GetAllByDepartment(long departmentId)
    {
            var data = await _db.Employers
            .Where(x => !x.isDeleted && x.DepartmentId == departmentId)
            .Include(x => x.Department).ToListAsync();


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

            return new BaseResponse<ICollection<GetEmployerDto>>(dataDtos);
    }


    public async Task<BaseResponse<PagedResponse<GetEmployerDto>>> GetAllAsync(int pageNumber, int pageSize)
    {
        var data = await _db.Employers
       .Where(x => !x.isDeleted )
       .Include(x => x.Department)
       .Skip((pageNumber - 1) * pageSize)
       .Take(pageSize)
       .ToListAsync();


        var totalCount = await _db.Employers
           .Where(x => !x.isDeleted)
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

    public async Task<BaseResponse<GetEmployerDto>> GetByIdAsync(long id)
    {
        var data = await _db.Employers
            .Include(x => x.Department) 
            .SingleOrDefaultAsync(x => !x.isDeleted && x.id == id);

        if (data == null)
        {
            return new BaseResponse<GetEmployerDto>(null, false);
        }

        var dataDto = new GetEmployerDto
        {
            Id = data.id,
            FullName = data.FullName,
            DepartmentId = data.DepartmentId,
            DepartmentName = data.Department?.Name, 
            Email = data.Email,
            Position = data.Position,
        };

        return new BaseResponse<GetEmployerDto>(dataDto);
    }


    public async Task<FileResponse<bool>> ImportFromExcelAsync(Stream excelFileStream)
    {
        var response = await _import.ImportFromExcelAsync(excelFileStream);

        if (!response.Success)
            return new FileResponse<bool>(false, false, response.Message);

        var callsList = response.Data;


        await _db.BulkInsertAsync(callsList);
        await _db.SaveChangesAsync();

        return new FileResponse<bool>(true, true, "Data successfully imported from Excel.");
    }

    public async Task<BaseResponse<GetEmployerDto>> RemoveAsync(long id)
    {
        var data = await _db.Employers.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetEmployerDto>(null, false);

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

    public async Task<BaseResponse<GetEmployerDto>> UpdateAsync(long id, CreateUpdateEmployerDto dto)
    {
        var data = await _db.Employers.SingleOrDefaultAsync(x => x.id==id && !x.isDeleted);
        
        data.Position = dto.Position;
        data.Email = dto.Email;
        data.DepartmentId = dto.DepartmentId;
        data.FullName = dto.FullName;

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
