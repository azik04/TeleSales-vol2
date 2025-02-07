using TeleSales.Core.Dto.Rel.Administration;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Rel.Administration;

public interface IAdministrationService
{
    Task<BaseResponse<GetAdministrationDto>> CreateAsync(CreateAdministrationDto dto);
    Task<BaseResponse<ICollection<GetAdministrationDto>>> GetAllAsync();
    Task<BaseResponse<GetAdministrationDto>> RemoveAsync(long id);
}
