using TeleSales.Core.Dto.Rel.Administration;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Rel.Administration;

public interface IAdministrationService
{
    Task<BaseResponse<AdministrationDto>> CreateAsync(AdministrationDto dto);
    Task<BaseResponse<AdministrationDto>> GetAllAsync();
}
