using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.Status;

public interface IStatusService
{
    Task<BaseResponse<Statuses>> CreateAsync(Statuses dto);
    Task<BaseResponse<ICollection<Statuses>>> GetAllAsync();
    Task<BaseResponse<Statuses>> RemoveAsync(long id);
}
