using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.Rel.Department;

namespace TeleSales.Controllers.Ref;

[Route("api/[controller]")]
[ApiController]

public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;
    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(long administrationId)
    {
        var res = await _service.GetAllByAdministration(administrationId);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
