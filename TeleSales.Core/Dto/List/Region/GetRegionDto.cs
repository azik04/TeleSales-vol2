namespace TeleSales.Core.Dto.List.Region;

public class GetRegionDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CityId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }

}
