using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.Region;

namespace TeleSales.Controllers.List;

[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _service;
    public RegionController(IRegionService service)
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
