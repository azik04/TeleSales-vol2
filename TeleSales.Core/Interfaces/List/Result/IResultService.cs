using TeleSales.Core.Dto.List.Result;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Result;

public interface IResultService
{
    Task<BaseResponse<ResultDto>> CreateAsync(ResultDto dto);
    Task<BaseResponse<ResultDto>> GetAllAsync();
}
