using TeleSales.DataProvider.Enums;

namespace TeleSales.Core.Dto.Main.Channel;

public class UpdateChannelDto
{
    public string Name { get; set; }
    public ChannelType Type { get; set; }

}
