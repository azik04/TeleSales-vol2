﻿namespace TeleSales.Core.Dto.Rel.Department;

public class GetDepartmentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AdministrationId { get; set; }
    public string AdministrationName { get; set; }
}
