namespace TeleSales.Core.Dto.Main.Debitor;

public class ExcludeDebitorDto
{
    public long ResultId { get; set; }
    public string? Note { get; set; }
    public long? ExcludedBy { get; set; }
    public DateTime? LastStatusUpdate { get; set; }
    public DateTime? NextCall { get; set; }
}
