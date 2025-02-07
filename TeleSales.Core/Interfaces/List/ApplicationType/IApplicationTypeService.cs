using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.ApplicationType;

public interface IApplicationTypeService
{
    Task<BaseResponse<ApplicationTypes>> CreateAsync(ApplicationTypes dto);
    Task<BaseResponse<ICollection<ApplicationTypes>>> GetAllAsync();
    Task<BaseResponse<ApplicationTypes>> RemoveAsync(long id);
}
