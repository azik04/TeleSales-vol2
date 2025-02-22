using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.List.Status;
using TeleSales.Core.Interfaces.List.Status;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


public class StatusController : ControllerBase
{
    private readonly IStatusService _service;
    public StatusController(IStatusService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateStatusDto dto)
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
