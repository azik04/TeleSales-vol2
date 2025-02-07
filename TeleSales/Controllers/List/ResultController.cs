using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.Result;

namespace TeleSales.Controllers.List;

[Route("api/[controller]")]
[ApiController]
public class ResultController : ControllerBase
{
    private readonly IResultService _service;
    public ResultController(IResultService service)
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
