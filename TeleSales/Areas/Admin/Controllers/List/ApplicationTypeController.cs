using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.ApplicationType;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ApplicationTypes dto)
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
