using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Entities.List;

public class Regions : Base
{
    public string Name { get; set; }
    public long CityId { get; set; }
    public Cities City { get; set; }
    public virtual ICollection<Uzadilmas> Uzadilmas { get; set; }
    public virtual ICollection<CallCenters> CallCenters { get; set; }

}
