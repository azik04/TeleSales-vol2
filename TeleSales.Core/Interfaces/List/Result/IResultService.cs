using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.Result;

public interface IResultService
{
    Task<BaseResponse<Results>> CreateAsync(Results dto);
    Task<BaseResponse<ICollection<Results>>> GetAllAsync();
    Task<BaseResponse<Results>> RemoveAsync(long id);

}
