using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NachoTacos.Server.Authentication.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("You are authorized!");
        }
    }
}
