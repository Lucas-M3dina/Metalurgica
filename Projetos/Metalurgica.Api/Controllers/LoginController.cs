using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Metalurgica.Controllers;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Services.Interfaces;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Common;
using System.Threading.Tasks;

namespace Metalurgica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService _loginService) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Logar(LoginRequest dadosLogin)
        {
            Retorno<LoginResponse> retorno = await _loginService.Logar(dadosLogin);
            return await Result(retorno);
        }
    }
}
