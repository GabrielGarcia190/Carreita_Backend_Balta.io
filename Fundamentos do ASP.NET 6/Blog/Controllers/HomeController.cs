using Blog.Attibutes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    // [ApiKey]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        [ApiKey]
        public IActionResult Get() => Ok(new { Mensagem = "Status: Operante" });
    }
}