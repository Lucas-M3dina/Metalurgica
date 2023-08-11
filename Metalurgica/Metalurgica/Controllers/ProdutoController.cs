using Biz.Interfaces;
using Entities;
using Entities.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILmProdutoService _produtoRepository;
        public ProdutoController(ILmProdutoService produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_produtoRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(ProdutoViewModel e)
        {
            try
            {
                _produtoRepository.Insere(e, User.Identity.Name);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Alterar(ProdutoViewModel elemento, int id)
        {
            try
            {
                _produtoRepository.Atualiza(id, elemento, User.Identity.Name);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _produtoRepository.Exclui(id, User.Identity.Name);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
