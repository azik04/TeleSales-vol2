﻿namespace TeleSales.Core.Dto.Main.Debitor;

public class UpdateDebitorDto
{
    public string LegalName { get; set; }
    public string VOEN { get; set; }
    public DateOnly? PermissionStartDate { get; set; }
    public DateOnly? PermissionEndDate { get; set; }
    public long InvoiceNumber { get; set; }
    public string Subject { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Phone { get; set; }


}
