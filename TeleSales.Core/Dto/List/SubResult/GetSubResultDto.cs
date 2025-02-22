namespace TeleSales.Core.Dto.List.SubResult;

public class GetSubResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long ResultId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }
}
