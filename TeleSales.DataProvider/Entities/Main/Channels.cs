using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Enums;

namespace TeleSales.DataProvider.Entities.Main;

public class Channels : Base // Fixed the class name
{
    public string Name { get; set; }
    public ChannelType Type { get; set; }
    public virtual ICollection<Debitors> Debitor { get; set; }
    public virtual ICollection<CallCenters> CallCenter { get; set; }
    public virtual ICollection<UserChannels> UserChannel { get; set; }
    public virtual ICollection<Uzadilmas> Uzadilma { get; set; }
}
