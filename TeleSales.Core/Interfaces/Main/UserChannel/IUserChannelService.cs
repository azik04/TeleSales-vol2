using TeleSales.Core.Dto.Main.Channel;
using TeleSales.Core.Dto.Main.User;
using TeleSales.Core.Dto.Main.UserChannel;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.UserChannel;

public interface IUserChannelService
{
    Task<BaseResponse<GetUserChannelDto>> AddToChannelAsync(CreateUserChannelDto dto);
    Task<BaseResponse<ICollection<GetChannelDto>>> GetAllByUserId(long userId);
    Task<BaseResponse<ICollection<GetUserDto>>> GetAllByChannelId(long channelId);
    Task<BaseResponse<GetUserChannelDto>> RemoveUserChannelAsync(long userId, long channelId);
}
