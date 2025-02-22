using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Rel.Administration;
using TeleSales.Core.Interfaces.Rel.Administration;

namespace TeleSales.Areas.Admin.Controllers.Ref;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]


public class AdministrationController : ControllerBase
{
    private readonly IAdministrationService _service;
    public AdministrationController(IAdministrationService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAdministrationDto dto)
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
