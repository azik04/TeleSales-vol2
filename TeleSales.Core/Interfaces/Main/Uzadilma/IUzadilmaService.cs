using TeleSales.Core.Dto.Main.Uzadilma;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.Uzadilma;

public interface IUzadilmaService
{
    Task<BaseResponse<GetUzadilmaDto>> CreateAsync(CreateUzadilmaDto dto, long channelId);
    Task<BaseResponse<PagedResponse<GetUzadilmaDto>>> GetAllByChannelAsync(int pageSize, int pageNumber, long channelId);
    //Task<BaseResponse<PagedResponse<GetUzadilmaDto>>> GetAllByChannelAndUserAsync(int pageSize, int pageNumber, long channelId , long userId);
    Task<BaseResponse<GetUzadilmaDto>> GetById(long id);
    Task<BaseResponse<GetUzadilmaDto>> RemoveAsync(long id);
    Task<BaseResponse<GetUzadilmaDto>> UpdateAsync(UpdateUzadilmaDto dto , long id);

}
