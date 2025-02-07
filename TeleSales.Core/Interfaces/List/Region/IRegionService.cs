using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.Region;

public interface IRegionService
{
    Task<BaseResponse<Regions>> CreateAsync(Regions dto);
    Task<BaseResponse<ICollection<Regions>>> GetAllAsync();
    Task<BaseResponse<Regions>> RemoveAsync(long id);

}
