using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Entities.List;

public class Results : Base
{
    public string Name { get; set; }
    public virtual ICollection<Debitors> Debitors { get; set; }

}
