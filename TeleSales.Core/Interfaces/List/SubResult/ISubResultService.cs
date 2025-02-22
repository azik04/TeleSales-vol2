using TeleSales.Core.Dto.List.SubResult;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.SubResult;

public interface ISubResultService
{
    Task<BaseResponse<GetSubResultDto>> CreateAsync(CreateSubResultDto dto);
    Task<BaseResponse<ICollection<GetSubResultDto>>> GetAllAsync(long resultId);
    Task<BaseResponse<GetSubResultDto>> RemoveAsync(long id);
}
