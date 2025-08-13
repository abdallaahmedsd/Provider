using Microsoft.AspNetCore.Mvc;
using Provider.Dtos;

namespace Provider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpPost("sum")]
        public IActionResult Sum([FromBody] NumbersRequest request)
        {
            var result = request.Number1 + request.Number2;
            return Ok(new { result });
        }
    }
}
