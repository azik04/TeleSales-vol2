using TeleSales.Core.Dto.List.City;
using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Core.Interfaces.List.City;

public interface ICityService
{
    Task<BaseResponse<GetCityDto>> CreateAsync (CreateCityDto dto);
    Task<BaseResponse<ICollection<GetCityDto>>> GetAllWithRegionsAsync();
    Task<BaseResponse<GetCityDto>> RemoveAsync(long id); 
}
