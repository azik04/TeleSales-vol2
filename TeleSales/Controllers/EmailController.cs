using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Dto.Email;
using TeleSales.Mail;

namespace TeleSales.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailDto request)
    {
        try
        {
            await _emailService.SendEmailAsync(request.To, request.Subject, request.Content);
            return Ok(new { message = "Email sent successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
