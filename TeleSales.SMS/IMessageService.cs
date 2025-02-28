using TeleSales.Core.Response;

namespace TeleSales.SMS;

public interface IMessageService
{
    Task<BaseResponse<bool>> SmsSender(long fromNumber, long toNumber);
    Task<BaseResponse<bool>> WpSender(long fromNumber, long toNumber);


}
