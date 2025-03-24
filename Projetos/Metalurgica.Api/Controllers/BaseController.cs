using System.Threading.Tasks;
using Metalurgica.Entities.Common;
using Microsoft.AspNetCore.Mvc;

namespace Metalurgica.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected Task<IActionResult> Result<T>(Retorno<T> retorno) where T : class 
        {
            if (!retorno.Success)
                retorno.Data = null;
            
            return Task.FromResult<IActionResult>(StatusCode((int)retorno.StatusCode, retorno));
        }

    }
}
