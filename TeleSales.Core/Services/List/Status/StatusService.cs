using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Interfaces.List.Status;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.List.Status;

public class StatusService : IStatusService
{
    public Task<BaseResponse<StatusDto>> CreateAsync(StatusDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<StatusDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
