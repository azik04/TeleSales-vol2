using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Interfaces.Main.Debitor;

namespace TeleSales.Areas.Admin.Controllers.Main;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

public class DebitorController : ControllerBase
{
    private readonly IDebitorService _service;
    public DebitorController(IDebitorService service)
    {
        _service = service;
    }


    /// <summary>
    /// Update a call by its ID
    /// </summary>
    /// <param name="id">The call ID</param>
    /// <param name="dto">The updated call details</param>
    /// <returns>The updated call data or an error message</returns>
    [HttpPut("{id}")]
    [Authorize(Policy = "Admin")]

    public async Task<IActionResult> UpdateAsync(long id, UpdateDebitorDto dto)
    {
        var res = await _service.UpdateAsync(id, dto);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Remove a call by its ID
    /// </summary>
    /// <param name="id">The call ID</param>
    /// <returns>A success message or an error message</returns>
    [HttpDelete("{id}")]
    [Authorize(Policy = "Admin")]

    public async Task<IActionResult> RemoveAsync(long id)
    {
        var res = await _service.RemoveAsync(id);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Import calls from an Excel file
    /// </summary>
    /// <param name="file">The Excel file containing call data</param>
    /// <returns>A response with the imported call data or error message</returns>
    [HttpPost("import")]
    public async Task<IActionResult> ImportFromExcelAsync(IFormFile file, long channelId)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using (var fileStream = file.OpenReadStream())
        {
            var response = await _service.ImportFromExcelAsync(fileStream, channelId);

            if (response.Success && response.ErrorFileBytes == null)
                return Ok(response);

            if (response.ErrorFileBytes != null)
                return File(response.ErrorFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ErrorReport.xlsx");

            return BadRequest(response.Message);
        }
    }

    /// <summary>
    /// Create a new call record
    /// </summary>
    /// <param name="dto">The details for the new call</param>
    /// <param name="kanalId">The channel to which the call belongs</param>
    /// <returns>A response with the created call data or an error message</returns>
    [HttpPost]
    [Authorize(Policy = "Admin")]

    public async Task<IActionResult> CreateAsync(CreateDebitorDto dto, long channelId)
    {
        var res = await _service.CreateAsync(dto, channelId);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Create a new call record
    /// </summary>
    /// <param name="dto">The details for the new call</param>
    /// <param name="kanalId">The channel to which the call belongs</param>
    /// <returns>A response with the created call data or an error message</returns>
    [HttpGet("Search")]

    public async Task<IActionResult> SearchAsync(long channelId, SearchDebitorDto dto, int pageNumber, int pageSize)
    {
        var res = await _service.SearchAsync(channelId, dto, pageNumber, pageSize);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }
}
