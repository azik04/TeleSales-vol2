using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Enums;

namespace TeleSales.DataProvider.Entities.Main;

public class Users : Base
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public virtual ICollection<Debitors> Debitor { get; set; }
    public virtual ICollection<UserChannels> UserChannel { get; set; }
    public virtual ICollection<CallCenters> CallCenter { get; set; }

}