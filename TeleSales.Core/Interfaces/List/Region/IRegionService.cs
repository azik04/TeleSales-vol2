using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.List.Region;

public interface IRegionService
{
    Task<BaseResponse<RegionDto>> CreateAsync(RegionDto dto);
    Task<BaseResponse<RegionDto>> GetAllAsync();
}
