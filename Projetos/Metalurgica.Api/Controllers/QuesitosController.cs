using System.Threading.Tasks;
using Metalurgica.Controllers;
using Metalurgica.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuesitosController(IQuesitoService quesitoService) : BaseController
    {
        private readonly IQuesitoService _quesitoService = quesitoService;

        [HttpGet]
        public async Task<IActionResult> GetAllEmbalagens()
        {
            var quesitos = await _quesitoService.ListAllQuesitos();
            return await Result(quesitos);
        }

    }
}
