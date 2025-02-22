using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Status;

public interface IStatusService
{
    Task<BaseResponse<GetStatusDto>> CreateAsync(CreateStatusDto dto);
    Task<BaseResponse<ICollection<GetStatusDto>>> GetAllAsync();
    Task<BaseResponse<GetStatusDto>> RemoveAsync(long id);
}
