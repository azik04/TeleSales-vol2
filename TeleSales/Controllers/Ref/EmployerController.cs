using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.Rel.Employer;

namespace TeleSales.Controllers.Ref;

[Route("api/[controller]")]
[ApiController]
public class EmployerController : ControllerBase
{
    private readonly IEmployerService _service;
    public EmployerController(IEmployerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize, long departmentId)
    {
        var res = await _service.GetAllByDepartment(pageNumber, pageSize, departmentId);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
