namespace TeleSales.Core.Dto.Main.Channel;

public class GetChannelDto
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
    public string Type { get; set; }
    public DateTime CreateAt { get; set; }
}
