using Biz.Interfaces;
using Biz.Services;
using Entities;
using Entities.Lote;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly ILmLoteService _loteRepository;
        public LoteController(ILmLoteService loteRepository)
        {
            _loteRepository = loteRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_loteRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(LoteViewModel e)
        {
            try
            {
                _loteRepository.Insere(e, User.Identity.Name);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Alterar(LoteViewModel elemento, int id)
        {
            try
            {
                _loteRepository.Atualiza(id, elemento, User.Identity.Name);
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
                _loteRepository.Exclui(id, User.Identity.Name);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
