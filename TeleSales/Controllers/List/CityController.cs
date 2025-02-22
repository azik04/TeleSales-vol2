using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.City;
using TeleSales.DataProvider.Context;

namespace TeleSales.Controllers.List;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _service;
    private readonly ApplicationDbContext _db;

    public CityController(ICityService service , ApplicationDbContext db)
    {
        _service = service;
        _db = db;
    }

    [HttpGet("Regions")]
    public async Task<IActionResult> GetAllWithRegionAsync()
    {
        var res = await _service.GetAllWithRegionsAsync();
        
            return Ok(res);

        return BadRequest(res);

    }
}
