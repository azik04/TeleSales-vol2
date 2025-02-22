using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.List.City;
using TeleSales.Core.Interfaces.List.City;

namespace TeleSales.Areas.Admin.Controllers.List;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _service;
    public CityController(ICityService service)
    {
        _service = service; 
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCityDto dto)
    {
        var res = await _service.CreateAsync(dto);
        if (res.Success)
            return Ok(res);
            
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        var res = await _service.RemoveAsync(id);
        if (res.Success)
            return Ok(res);

        return BadRequest();
    }
}
