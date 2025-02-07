using TeleSales.Core.Dto.Rel.Department;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Rel.Department;

public interface IDepartmentService
{
    Task<BaseResponse<GetDepartmentDto>> CreateAsync(CreateUpdateDepartmentDto dto);
    Task<BaseResponse<ICollection<GetDepartmentDto>>> GetAllByAdministration(long  administrationId);
    Task<BaseResponse<GetDepartmentDto>> RemoveAsync(long id);
}
