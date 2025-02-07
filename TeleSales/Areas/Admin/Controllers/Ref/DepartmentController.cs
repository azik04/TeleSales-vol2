using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Rel.Department;
using TeleSales.Core.Interfaces.Rel.Department;

namespace TeleSales.Areas.Admin.Controllers.Ref;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateDepartmentDto dto)
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
