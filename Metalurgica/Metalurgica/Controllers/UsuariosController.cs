using Metalurgica.Interfaces;
using Metalurgica.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar(){
            try
            {
                return Ok(_usuarioRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpPost]
        public IActionResult Criar(LmUsuario u)
        {
            try
            {
                _usuarioRepository.Insere(u);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(LmUsuario user, int id)
        {
            try
            {
                _usuarioRepository.Atualiza(id, user);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Exclui(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}