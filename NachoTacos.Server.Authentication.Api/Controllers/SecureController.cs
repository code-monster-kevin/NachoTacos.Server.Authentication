using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("Fruit")]
        public IActionResult GetFruits()
        {
            List<string> fruits = new List<string>
            {
                "Apple",
                "Orange",
                "Pineapple"
            };

            return Ok(fruits);
        }
    }
}
