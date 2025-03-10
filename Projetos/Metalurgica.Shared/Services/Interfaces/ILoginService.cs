using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Retorno<LoginResponse>> Logar(LoginRequest dadosLogin);
    }
}
