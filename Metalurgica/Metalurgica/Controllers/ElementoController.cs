using Biz.Interfaces;
using Biz.Services;
using Data.Models;
using Entities.Elemento;
using Entities.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementoController : ControllerBase
    {
        private readonly ILmElementoService _elementoRepository;
        public ElementoController(ILmElementoService elementoRepository)
        {
            _elementoRepository = elementoRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_elementoRepository.ConsultaTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(ElementoViewModel e)
        {
            try
            {
                _elementoRepository.Insere(e, User.Identity.Name);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Alterar(ElementoViewModel elemento, int id)
        {
            try
            {
                _elementoRepository.Atualiza(id, elemento, User.Identity.Name);
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
                _elementoRepository.Exclui(id, User.Identity.Name);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}
