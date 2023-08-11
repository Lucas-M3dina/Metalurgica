using Biz.Interfaces;
using Data.Models;
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


        [HttpPost]
        public IActionResult Criar(LmEmpresa u)
        {
            try
            {
                _empresaRepository.Insere(u, u.NmNome);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Alterar(LmEmpresa user, int id)
        {
            try
            {
                _empresaRepository.Atualiza(id, user);
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
