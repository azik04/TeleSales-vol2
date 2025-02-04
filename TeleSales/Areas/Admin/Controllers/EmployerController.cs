using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Main.Employer;
using TeleSales.Core.Services.Employer;

namespace TeleSales.Areas.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployerController : ControllerBase
{
    private readonly EmployerService _service;
    public EmployerController(EmployerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployerDto data)
    {
        var res = await _service.CreateAsync(data);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpPost]
    public async Task<IActionResult> ImportFromExcelAsync(IFormFile file)
    {
        var res = await _service.ImportFromExcelAsync(file);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
    {
        var res = await _service.GetAllAsync(pageNumber,  pageSize);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id , UpdateEmployerDto dto)
    {
        var res = await _service.UpdateAsync(id , dto);
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
