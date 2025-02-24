using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Main.Uzadilma;
using TeleSales.Core.Interfaces.Main.Uzadilma;

namespace TeleSales.Areas.Admin.Controllers.Main;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

public class UzadilmaController : ControllerBase
{
    private readonly IUzadilmaService _service;
    public UzadilmaController(IUzadilmaService service)
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

    public async Task<IActionResult> UpdateAsync(UpdateUzadilmaDto dto, long id )
    {
        var res = await _service.UpdateAsync(dto,id);
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



    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUzadilmaDto dto, long channelId)
    {
        var res = await _service.CreateAsync(dto, channelId);
        if (!res.Success)
            return BadRequest(res.Message);

        return Ok(res);
    }
}
