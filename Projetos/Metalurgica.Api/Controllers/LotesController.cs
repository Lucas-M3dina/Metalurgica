using System.Threading.Tasks;
using Metalurgica.Controllers;
using Metalurgica.Entities.Request;
using Metalurgica.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController(ILoteService loteService) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> PostLote(LoteRequest request)
        {
            var lote = await loteService.CreateLote(request);
            return await Result(lote);
        }
    }
}
