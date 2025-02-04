namespace TeleSales.Core.Dto.Main.UserChannel;

public class GetUserChannelDto
{
    public long ChannelId { get; set; }
    public string? ChannelName { get; set; }
    public long UserId { get; set; }
    public string? UserEmail { get; set; }
    public string Type { get; set; }
}
