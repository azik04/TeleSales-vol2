using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Rel.Employer;
using TeleSales.Core.Interfaces.Rel.Employer;

namespace TeleSales.Areas.Admin.Controllers.Ref;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

public class EmployerController : ControllerBase
{
    private readonly IEmployerService _service;
    public EmployerController(IEmployerService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
    {
        var res = await _service.GetAllAsync(pageNumber, pageSize);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var res = await _service.GetByIdAsync(id);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }

    [HttpPost("import")]

    public async Task<IActionResult> ImportFromExcel(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using (var fileStream = file.OpenReadStream())
        {
            var response = await _service.ImportFromExcelAsync(fileStream);

            if (response.Success)
                return Ok(response);

            if (response.ErrorFileBytes != null)
            {
                return File(response.ErrorFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ErrorReport.xlsx");
            }

            return BadRequest(response.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateEmployerDto dto)
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id , CreateUpdateEmployerDto dto)
    {
        var res = await _service.UpdateAsync(id, dto);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
