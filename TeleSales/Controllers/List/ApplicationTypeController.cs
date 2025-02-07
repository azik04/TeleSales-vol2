using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.ApplicationType;

namespace TeleSales.Controllers.List;

[Route("api/[controller]")]
[ApiController]
public class ApplicationTypeController : ControllerBase
{
    private readonly IApplicationTypeService _service;
    public ApplicationTypeController(IApplicationTypeService service)
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
