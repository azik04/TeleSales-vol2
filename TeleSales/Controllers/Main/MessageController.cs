using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleSales.SMS;

namespace TeleSales.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpPost("Sms")]
        public async Task<IActionResult> SmsSender(long fromNumber, long toNumber)
        {
            var res = await _service.SmsSender(fromNumber, toNumber);
            if (res.Success)
                return Ok(res);

            return BadRequest(res);
        }

        [HttpPost("Wp")]
        public async Task<IActionResult> WpSender(long fromNumber, long toNumber)
        {
            var res = await _service.WpSender(fromNumber, toNumber);
            if (res.Success)
                return Ok(res);

            return BadRequest(res);
        }

    }
}
