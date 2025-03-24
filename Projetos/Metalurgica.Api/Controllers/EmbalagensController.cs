using System.Threading.Tasks;
using Metalurgica.Controllers;
using Metalurgica.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbalagensController(IEmbalagemService embalagemService) : BaseController
    {
        private readonly IEmbalagemService _embalagemService = embalagemService;

        [HttpGet]
        public async Task<IActionResult> GetAllEmbalagens()
        {
            var products = await _embalagemService.ListAllEmbalagens();
            return await Result(products);
        }

    }
}
