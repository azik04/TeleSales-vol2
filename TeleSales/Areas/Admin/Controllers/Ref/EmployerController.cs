using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Interfaces.Rel.Employer;

namespace TeleSales.Areas.Admin.Controllers.Ref;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateEmployerDto dto)
    {
        var res = await _service.CreateAsync(dto);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        var res = await _service.RemoveAsync(id);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
