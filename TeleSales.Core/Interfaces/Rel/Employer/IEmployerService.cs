using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Rel.Employer;

public interface IEmployerService
{
    Task<BaseResponse<GetEmployerDto>> UpdateAsync(long id ,CreateUpdateEmployerDto dto);
    Task<BaseResponse<GetEmployerDto>> CreateAsync(CreateUpdateEmployerDto dto);
    Task<BaseResponse<ICollection<GetEmployerDto>>> GetAllByDepartment(long departmentId);
    Task<BaseResponse<PagedResponse<GetEmployerDto>>> GetAllAsync(int pageNumber, int pageSize);
    Task<BaseResponse<GetEmployerDto>> GetByIdAsync(long id);
    Task<BaseResponse<GetEmployerDto>> RemoveAsync(long id);
    Task<FileResponse<bool>> ImportFromExcelAsync(Stream excelFileStream);

}
