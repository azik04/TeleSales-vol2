using TeleSales.Core.Dto.Main.Channel;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.Channel;

public interface IChannelService
{
    Task<BaseResponse<GetChannelDto>> Create(CreateChannelDto dto);
    Task<BaseResponse<ICollection<GetChannelDto>>> GetAll();
    Task<BaseResponse<GetChannelDto>> GetById(long id);
    Task<BaseResponse<GetChannelDto>> Update(long id, UpdateChannelDto dto);
    Task<BaseResponse<GetChannelDto>> Remove(long id);
}
