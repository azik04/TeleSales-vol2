namespace TeleSales.Core.Dto.Main.CallCenter;

public class UpdateCallCenterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long RegionId { get; set; }
    public string Phone { get; set; }
    public long VOEN { get; set; }
    public long ApplicationTypeId { get; set; }
    public string ShortContent { get; set; }
    public string DetailsContent { get; set; }
    public bool isForwarding { get; set; }

    public long? AdministrationId { get; set; }
    public long? DepartmentId { get; set; }
    public long? EmployerId { get; set; }
    public string Conclusion { get; set; }
    public string? Addition { get; set; }
}
