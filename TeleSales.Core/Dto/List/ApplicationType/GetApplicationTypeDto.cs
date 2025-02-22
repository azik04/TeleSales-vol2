namespace TeleSales.Core.Dto.List.ApplicationType;

public class GetApplicationTypeDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }

}
