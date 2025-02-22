using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.Status;

namespace TeleSales.Controllers.List;

[Route("api/[controller]")]
[ApiController]

public class StatusController : ControllerBase
{
    private readonly IStatusService _service;
    public StatusController(IStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _service.GetAllAsync();
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
