using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Region;

public interface IRegionService
{
    Task<BaseResponse<GetRegionDto>> CreateAsync(CreateRegionDto dto);
    Task<BaseResponse<ICollection<GetRegionDto>>> GetAllAsync();
    Task<BaseResponse<GetRegionDto>> RemoveAsync(long id);

}
