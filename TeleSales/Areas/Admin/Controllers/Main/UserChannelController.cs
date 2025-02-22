using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Main.UserChannel;
using TeleSales.Core.Interfaces.Main.UserChannel;

namespace TeleSales.Areas.Admin.Controllers.Main;

[Route("api/Admin/[controller]")]
[ApiController]
[Area("Admin")]

public class UserChannelController : ControllerBase
{
    private readonly IUserChannelService _service;

    public UserChannelController(IUserChannelService service)
    {
        _service = service;
    }


    /// <summary>
    /// Добавляет пользователя в канал.
    /// </summary>
    /// <param name="dto">Данные для добавления пользователя в канал.</param>
    /// <returns>Результат операции (успех или ошибка).</returns>
    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddToChannelAsync(CreateUserChannelDto dto)
    {
        var data = await _service.AddToChannelAsync(dto);
        if (data.Success)
            return Ok(data);
        return BadRequest();
    }


    /// <summary>
    /// Получает список пользователей по ID канала.
    /// </summary>
    /// <param name="kanalId">ID канала.</param>
    /// <returns>Список пользователей в указанном канале.</returns>
    [HttpGet("ByChannal")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetAllByChannelId(long channelId)
    {
        var data = await _service.GetAllByChannelId(channelId);
        if (data.Success)
            return Ok(data);
        return BadRequest();
    }


    /// <summary>
    /// Удаляет пользователя из канала.
    /// </summary>
    /// <param name="userId">ID пользователя.</param>
    /// <param name="kanalId">ID канала.</param>
    /// <returns>Результат операции (успех или ошибка).</returns>
    [HttpDelete]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> RemoveUserFromChannelAsync(long userId, long channelId)
    {
        var data = await _service.RemoveUserChannelAsync(userId, channelId);
        if (data.Success)
            return Ok(data);
        return BadRequest();
    }
}
