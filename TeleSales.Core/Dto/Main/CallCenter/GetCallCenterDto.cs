namespace TeleSales.Core.Dto.Main.CallCenter;

public class GetCallCenterDto
{
    public long id { get; set; }
    public long ChannelId { get; set; }
    public string ChannelName { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; }
    public string FullName { get; set; }
    public long RegionId { get; set; }
    public string RegionName { get; set; }
    public string Phone { get; set; }
    public long ExcludedBy { get; set; }
    public string ExcludedByName { get; set; }
    public long VOEN { get; set; }
    public long ApplicationTypeId { get; set; }
    public string ApplicationTypeName { get; set; }
    public string ShortContent { get; set; }
    public string DetailsContent { get; set; }
    public bool Forwarding { get; set; }


    public long? AdministrationId { get; set; }
    public string AdministrationName { get; set; }
    public long? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public long? EmployerId { get; set; }
    public string? EmployerName { get; set; }
    public string Conclusion { get; set; }
    public string? Addition { get; set; }

}
