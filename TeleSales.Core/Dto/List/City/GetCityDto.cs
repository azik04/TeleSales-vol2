using TeleSales.Core.Dto.List.Region;

namespace TeleSales.Core.Dto.List.City;

public class GetCityDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<GetRegionDto> Regions { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }
}
