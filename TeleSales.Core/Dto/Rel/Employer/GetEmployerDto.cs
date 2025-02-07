namespace TeleSales.Core.Dto.Rel.Employer;

public class GetEmployerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public long DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string Position { get; set; }

}
