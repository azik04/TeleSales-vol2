using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Interfaces.List.Region;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.List.Region;

public class RegionService : IRegionService
{
    public Task<BaseResponse<RegionDto>> CreateAsync(RegionDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<RegionDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
