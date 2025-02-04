using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Status;

public interface IStatusService
{
    Task<BaseResponse<StatusDto>> CreateAsync(StatusDto dto);
    Task<BaseResponse<StatusDto>> GetAllAsync();
}
