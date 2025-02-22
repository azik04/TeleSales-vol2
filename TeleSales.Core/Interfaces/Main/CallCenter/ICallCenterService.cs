using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.CallCenter;

public interface ICallCenterService
{
    Task<BaseResponse<byte[]>> ExportToExcelAsync(long channelId);
    Task<BaseResponse<GetCallCenterDto>> CreateAsync(CreateCallCenterDto dto, long channelId);
    Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllByUserAsync(long userId, long channelId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllAsync(long channelId, int pageNumber, int pageSize);
    Task<BaseResponse<GetCallCenterDto>> GetByIdAsync(long id);
    Task<BaseResponse<GetCallCenterDto>> UpdateAsync(long id, UpdateCallCenterDto dto);
    Task<BaseResponse<GetCallCenterDto>> RemoveAsync(long id);
}
