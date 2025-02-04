using TeleSales.Core.Dto.List.ApplicationType;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.ApplicationType;

public interface IApplicationTypeService
{
    Task<BaseResponse<ApplicationTypeDto>> CreateAsync(ApplicationTypeDto dto);
    Task<BaseResponse<ApplicationTypeDto>> GetAllAsync();
}
