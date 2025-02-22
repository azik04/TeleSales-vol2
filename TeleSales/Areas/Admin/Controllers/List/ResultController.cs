using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.List.Result;
using TeleSales.Core.Interfaces.List.Result;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


public class ResultController : ControllerBase
{
    private readonly IResultService _service;
    public ResultController(IResultService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateResultDto dto)
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
