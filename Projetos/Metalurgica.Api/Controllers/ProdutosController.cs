using System.Threading.Tasks;
using Metalurgica.Controllers;
using Metalurgica.Entities.Request;
using Metalurgica.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController(IProdutoService produtoService) : BaseController
    {
        private readonly IProdutoService _produtoService = produtoService;

        [HttpGet("filter")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _produtoService.ListProductsFilter();
            return await Result(products);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductSelect()
        {
            var products = await _produtoService.ListProductsSelect();
            return await Result(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProdutoRequest request)
        {
            var products = await _produtoService.CreateProduct(request);
            return await Result(products);
        }
    }
}
