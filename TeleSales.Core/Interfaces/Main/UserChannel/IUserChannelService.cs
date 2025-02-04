using TeleSales.Core.Dto.Main.Channel;
using TeleSales.Core.Dto.Main.User;
using TeleSales.Core.Dto.Main.UserChannel;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.UserChannel;

public interface IUserChannelService
{
    Task<BaseResponse<GetUserChannelDto>> AddToChanelAsync(CreateUserChannelDto dto);
    Task<BaseResponse<ICollection<GetChannelDto>>> GetAllByUserId(long userId);
    Task<BaseResponse<ICollection<GetUserDto>>> GetAllByKanalId(long kanalId);
    Task<BaseResponse<GetUserChannelDto>> RemoveUserKanalAsync(long userId, long kanalId);
}
