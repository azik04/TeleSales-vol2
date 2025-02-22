using TeleSales.Core.Dto.List.ApplicationType;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.ApplicationType;

public interface IApplicationTypeService
{
    Task<BaseResponse<GetApplicationTypeDto>> CreateAsync(CreateApplicationTypeDto dto);
    Task<BaseResponse<ICollection<GetApplicationTypeDto>>> GetAllAsync();
    Task<BaseResponse<GetApplicationTypeDto>> RemoveAsync(long id);
}
