using TeleSales.Core.Dto.List.Result;
using TeleSales.Core.Interfaces.List.Result;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.List.Result;

public class ResultService : IResultService
{
    public Task<BaseResponse<ResultDto>> CreateAsync(ResultDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<ResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
