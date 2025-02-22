using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.Main.UserChannel;

namespace TeleSales.Controllers.Main;

[Route("api/[controller]")]
[ApiController]

public class UserChannelController : ControllerBase
{
    private readonly IUserChannelService _service;

    public UserChannelController(IUserChannelService service)
    {
        _service = service;
    }


    /// <summary>
    /// Получает список каналов по ID пользователя.
    /// </summary>
    /// <param name="userId">ID пользователя.</param>
    /// <returns>Список каналов, в которых состоит указанный пользователь.</returns>
    [HttpGet("ByUser")]
    [Authorize(Policy = "Operator")]

    public async Task<IActionResult> GetAllByUserId(long userId)
    {
        var data = await _service.GetAllByUserId(userId);
        if (data.Success)
            return Ok(data);
        return BadRequest();
    }
}
