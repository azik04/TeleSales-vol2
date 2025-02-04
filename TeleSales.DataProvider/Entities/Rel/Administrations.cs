using TeleSales.DataProvider.Entities.BaseModel;

namespace TeleSales.DataProvider.Entities.Rel;

public class Administrations : Base
{
    public string Name { get; set; }
    public virtual ICollection<Departments> Department { get; set; }
}
