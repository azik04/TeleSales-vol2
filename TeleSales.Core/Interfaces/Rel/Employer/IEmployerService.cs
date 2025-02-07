using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Rel.Employer;

public interface IEmployerService
{
    Task<BaseResponse<GetEmployerDto>> CreateAsync(CreateUpdateEmployerDto dto);
    Task<BaseResponse<PagedResponse<GetEmployerDto>>> GetAllByDepartment(int pageNumber, int pageSize, long departmentId);
    Task<BaseResponse<GetEmployerDto>> RemoveAsync(long id);


}
