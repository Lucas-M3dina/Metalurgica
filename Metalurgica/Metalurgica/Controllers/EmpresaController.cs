using Biz.Interfaces;
using Data.Models;
using Entities.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly ILmEmpresaService _empresaRepository;
        public EmpresaController(ILmEmpresaService empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_empresaRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(EmpresaViewModel e)
        {
            try
            {
                _empresaRepository.Insere(e, User.Identity.Name);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Alterar(EmpresaViewModel empresa, int id)
        {
            try
            {
                _empresaRepository.Atualiza(id, empresa, User.Identity.Name);
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
                _empresaRepository.Exclui(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
