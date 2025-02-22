using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.List.SubResult;
using TeleSales.Core.Interfaces.List.SubResult;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

public class SubResultController : ControllerBase
{
    private readonly ISubResultService _service;
    public SubResultController(ISubResultService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSubResultDto dto)
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
