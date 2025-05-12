using Metalurgica.Controllers;
using Metalurgica.Entities.Request;
using Metalurgica.Shared.Services;
using Metalurgica.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadosController(ICertificateService certificateService) : BaseController
    {
        [HttpGet("{idCertificado}")]
        public async Task<IActionResult> GetCertificate(int idCertificado)
        {
            var certificate = await certificateService.GenerateCertificate(idCertificado);
            return await Result(certificate);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCertificate()
        {
            var certificate = await certificateService.GetAllCertificates();
            return await Result(certificate);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(CertificateRequest request)
        {
            var certificate = await certificateService.CreateCertificate(request);
            return await Result(certificate);
        }
    }
    
}
