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

    }
}