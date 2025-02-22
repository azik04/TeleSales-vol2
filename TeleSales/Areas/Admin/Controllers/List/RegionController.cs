using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.List.Region;
using TeleSales.Core.Interfaces.List.Region;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


public class RegionController : ControllerBase
{
    private readonly IRegionService _service;
    public RegionController(IRegionService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRegionDto dto)
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
