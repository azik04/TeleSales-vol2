using TeleSales.Core.Dto.List.Result;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Result;

public interface IResultService
{
    Task<BaseResponse<GetResultDto>> CreateAsync(CreateResultDto dto);
    Task<BaseResponse<ICollection<GetResultDto>>> GetAllAsync();
    Task<BaseResponse<GetResultDto>> RemoveAsync(long id);

}
