using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.Main.Uzadilma;

namespace TeleSales.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzadilmaController : ControllerBase
    {
        private readonly IUzadilmaService _service;
        public UzadilmaController(IUzadilmaService service)
        {
            _service = service;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllByChannelAsync(int pageSize, int pageNumber, long channelId)
        {
            var res = await _service.GetAllByChannelAsync(pageSize, pageNumber, channelId);
            if (!res.Success)
                return BadRequest(res.Message);

            return Ok(res);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var res = await _service.GetById(id);
            if (!res.Success)
                return BadRequest(res.Message);

            return Ok(res);
        }
    }
}
