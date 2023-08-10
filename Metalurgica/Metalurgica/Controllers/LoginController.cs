using Biz.Interfaces;
using Data.Models;
using Entities.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILmUsuarioService _usuarioRepository;

        public LoginController(ILmUsuarioService usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginViewModel user)
        {
            try
            {
                UsuarioLoginViewModel test = user;

                LmUsuario usuarioBuscado = _usuarioRepository.Login(user);

                if (usuarioBuscado == null)
                {
                    return Unauthorized();
                }


                string token = TokenServiceFilter.GerarToken(usuarioBuscado);
                usuarioBuscado.DsSenha = "";
                return Ok(new {
                    user = usuarioBuscado, 
                    token = token
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
