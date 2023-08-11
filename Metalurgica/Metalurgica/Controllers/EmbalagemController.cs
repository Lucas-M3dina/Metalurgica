using Biz.Interfaces;
using Entities;
using Entities.Elemento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbalagemController : ControllerBase
    {
        private readonly ILmEmbalagemService _embalagemRepository;
        public EmbalagemController(ILmEmbalagemService embalagemRepository)
        {
            _embalagemRepository = embalagemRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_embalagemRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(EmbalagemViewModel e)
        {
            try
            {
                _embalagemRepository.Insere(e, User.Identity.Name);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Alterar(EmbalagemViewModel elemento, int id)
        {
            try
            {
                _embalagemRepository.Atualiza(id, elemento, User.Identity.Name);
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
                _embalagemRepository.Exclui(id, User.Identity.Name);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
