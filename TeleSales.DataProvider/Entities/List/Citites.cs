using TeleSales.DataProvider.Entities.BaseModel;

namespace TeleSales.DataProvider.Entities.List;

public class Cities : Base
{
    public string Name { get; set; }
    public ICollection<Regions> Regions { get; set; }
}
