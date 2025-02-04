using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Entities.Rel;

public class Departments : Base
{
    public string Name { get; set; }
    public long AdministrationId { get; set; }
    public Administrations Administration { get; set; }
    public virtual ICollection<Employers> Employer { get; set; }
    public virtual ICollection<Uzadilmas> Uzadilma { get; set; }
    public virtual ICollection<CallCenters> CallCenter { get; set; }


}
