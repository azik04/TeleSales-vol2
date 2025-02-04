using TeleSales.DataProvider.Entities.BaseModel;
using TeleSales.DataProvider.Entities.List;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.DataProvider.Entities.Main;

public class CallCenters : Base
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public long VOEN { get; set; }
    public string ShortContent { get; set; }
    public string DetailsContent { get; set; }
    public string Conclusion { get; set; }
    public bool isForwarding { get; set; }
    public string? ForwardTo { get; set; }
    public string? Addition { get; set; }
    public long ExcludedBy { get; set; }
    public Users User { get; set; }


    public long СhannelId { get; set; }
    public Сhannels Сhannel { get; set; }
    public long? AdministrationId { get; set; }
    public Administrations? Administration { get; set; }
    public long? DepartmentId { get; set; }
    public Departments? Department { get; set; }
    public long? EmployerId { get; set; }
    public Employers? Employer { get; set; }
    public long? RegionId { get; set; }
    public Regions? Region { get; set; }
    public long ApplicationTypeId { get; set; }
    public ApplicationTypes ApplicationType { get; set; }
}
