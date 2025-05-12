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
        public async Task<IActionResult> GetAllQuesitos()
        {
            var quesitos = await _quesitoService.ListAllQuesitos();
            return await Result(quesitos);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAllQuesitosByIdProduct(int productId)
        {
            var quesitos = await _quesitoService.ListAllQuesitosbyIdProduto(productId);
            return await Result(quesitos);
        }

    }
}
