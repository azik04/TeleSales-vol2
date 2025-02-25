using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Interfaces.Main.Debitor;

namespace TeleSales.Controllers.Main;

[Route("api/[controller]")]
[ApiController]
public class DebitorController : ControllerBase
{
    private readonly IDebitorService _service;
    public DebitorController(IDebitorService service)
    {
        _service = service;
    }


    /// <summary>
    /// Get all calls that are not excluded
    /// </summary>
    /// <param name="channelId">The channel ID</param>
    /// <param name="pageNumber">The page number for pagination</param>
    /// <param name="pageSize">The number of records per page</param>
    /// <returns>A paginated list of calls that are not excluded</returns>
    [HttpGet("NotExcluded")]
    [Authorize(Policy = "Viewer")]
    public async Task<IActionResult> GetAllNotExcludedAsync(long channelId, int pageNumber, int pageSize)
    {
        var res = await _service.GetAllNotExcludedAsync(channelId, pageNumber, pageSize);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }

    /// <summary>
    /// Get all calls that are excluded
    /// </summary>
    /// <param name="channelId">The channel ID</param>
    /// <param name="pageNumber">The page number for pagination</param>
    /// <param name="pageSize">The number of records per page</param>
    /// <returns>A paginated list of excluded calls</returns>
    [HttpGet("Excluded")]
    [Authorize(Policy = "Viewer")]

    public async Task<IActionResult> GetAllExcludedAsync(long channelId, int pageNumber, int pageSize)
    {
        var res = await _service.GetAllExcludedAsync(channelId, pageNumber, pageSize);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }

    /// <summary>
    /// Export calls to an Excel file
    /// </summary>
    /// <param name="channelId">The channel ID to filter calls</param>
    /// <returns>The Excel file containing the exported call data</returns>
    [HttpGet("ExportExcel")]
    [Authorize(Policy = "Viewer")]
    public async Task<IActionResult> ExportToExcelAsync(long channelId)
    {
        try
        {
            var fileBytes = await _service.ExportToExcelAsync(channelId);

            if (fileBytes.Data == null || fileBytes.Data.Length == 0)
                return BadRequest(new { Message = "No data found to export." });

            var fileName = $"Calls_{channelId}_{DateTime.UtcNow:yyyyMMdd}.xlsx";

            return File(fileBytes.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"An error occurred: {ex.Message}" });
        }
    }




    /// <summary>
    /// Get all calls by channel ID and user ID with pagination
    /// </summary>
    /// <param name="userId">The user ID</param>
    /// <param name="pageNumber">The page number for pagination</param>
    /// <param name="pageSize">The number of records per page</param>
    /// <returns>A paginated list of calls by channel and user</returns>
    [HttpGet("Channel/{channelId}/User/{userId}")]
    [Authorize(Policy = "Operator")]

    public async Task<IActionResult> GetAllByUserAsync(long userId, long channelId, int pageNumber, int pageSize)
    {
        var res = await _service.GetAllByUserAsync(userId, channelId, pageNumber, pageSize);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Get a random call
    /// </summary>
    /// <returns>A random call from the database</returns>
    [HttpGet("Random")]
    [Authorize(Policy = "Operator")]
    public async Task<IActionResult> GetRandomDebitorAsync(long channelId, long userId)
    {
        var res = await _service.GetRandomDebitorAsync(channelId, userId);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Get a call by its ID
    /// </summary>
    /// <param name="id">The call ID</param>
    /// <returns>The call details if found</returns>
    [HttpGet("{id}")]
    [Authorize]

    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var res = await _service.GetByIdAsync(id);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }


    /// <summary>
    /// Exclude a call by its ID
    /// </summary>
    /// <param name="id">The call ID</param>
    /// <param name="dto">The details for excluding the call</param>
    /// <returns>The excluded call or an error message</returns>
    [HttpPut("Exclude/{id}")]
    [Authorize(Policy = "Operator")]

    public async Task<IActionResult> ExcludeAsync(long id, ExcludeDebitorDto dto)
    {
        var res = await _service.ExcludeAsync(id, dto);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }
}
