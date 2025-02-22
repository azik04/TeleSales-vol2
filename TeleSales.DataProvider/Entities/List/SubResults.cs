using TeleSales.DataProvider.Entities.BaseModel;

namespace TeleSales.DataProvider.Entities.List;

public class SubResults : Base
{
    public string Name { get; set; }
    public long ResultId { get; set; }
    public Results Results { get; set; }
}
