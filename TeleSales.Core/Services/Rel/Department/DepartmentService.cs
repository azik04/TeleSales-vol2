using TeleSales.Core.Dto.Rel.Department;
using TeleSales.Core.Interfaces.Rel.Department;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.Rel.Department;

public class DepartmentService : IDepartmentService
{
    public Task<BaseResponse<GetDepartmentDto>> CreateAsync(CreateUpdateDepartmentDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<GetDepartmentDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
