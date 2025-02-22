using Microsoft.AspNetCore.Mvc;
using TeleSales.Core.Interfaces.List.SubResult;

namespace TeleSales.Controllers.List
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubResultController : ControllerBase
    {
        private readonly ISubResultService _service;
        public SubResultController(ISubResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(long resultId)
        {
            var res = await _service.GetAllAsync(resultId);
            if (res.Success)
                return Ok(res);

            return BadRequest(res);
        }
    }
}
