namespace TeleSales.Core.Dto.Main.Uzadilma;

public class UpdateUzadilmaDto
{
    public long DepartmentId { get; set; }
    public long RegionId { get; set; }


    public string Adress { get; set; }
    public long MuraciyetNomresi { get; set; }
    public DateOnly? PermissionStartDate { get; set; }
    public DateOnly? PermissionEndDate { get; set; }
    public string Yayici { get; set; }
    public long VOEN { get; set; }
    public string Zona { get; set; }
    public string DasiyiciNovu { get; set; }
    public string IcazeMuddeti { get; set; }
    public string TəyinatVöen { get; set; }
    public string MüraciətSayı { get; set; }
    public string DaşıyıcıSayı { get; set; }
}
