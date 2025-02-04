using TeleSales.DataProvider.Entities.BaseModel;

namespace TeleSales.DataProvider.Entities.Rel;

public class Employers : Base
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public long DepartmentId { get; set; }
    public Departments Department { get; set; }
}
