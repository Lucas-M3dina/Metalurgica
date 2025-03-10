using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface IQuesitoService
    {
        Task<Retorno<IEnumerable<QuesitoResponse>>> ListAllQuesitos();
    }
}