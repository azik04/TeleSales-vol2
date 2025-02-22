namespace TeleSales.Core.Dto.List.Result;

public class GetResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }
}
