using System.Threading.Tasks;
using Metalurgica.Controllers;
using Metalurgica.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            return Ok("Pong");
        }
    }
}
