﻿using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Main.AUTH;
using TeleSales.Core.Interfaces.Main.Auth;

namespace TeleSales.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService _service;

    public AccountController(IAuthService service)
    {
        _service = service;
    }

    /// <summary>
    /// Log in a user with the provided authentication details
    /// </summary>
    /// <param name="dto">The authentication data containing the user's credentials</param>
    /// <returns>A response with the authentication result, typically including a token if successful</returns>
    [HttpPost]
    public async Task<IActionResult> LogIn(AuthDto dto)
    {
        var res = await _service.LogIn(dto);
        if (res.Success)
            return Ok(res);

        return BadRequest(res);
    }
}
