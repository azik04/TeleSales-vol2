using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.Rel.Administration;

namespace TeleSales.Controllers.Ref;

[Route("api/[controller]")]
[ApiController]


public class AdministrationController : ControllerBase
{
    private readonly IAdministrationService _service;
    public AdministrationController(IAdministrationService service)
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
