using TeleSales.DataProvider.Entities.BaseModel;

namespace TeleSales.DataProvider.Entities.Main;

public class UserChannels : Base
{
    public long UserId { get; set; }
    public long СhannelId { get; set; }

    public virtual Users User { get; set; }
    public virtual Сhannels Сhannel { get; set; }
}
