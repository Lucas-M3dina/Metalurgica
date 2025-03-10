using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface IEmbalagemService
    {
        Task<Retorno<IEnumerable<EmbalagemResponse>>> ListAllEmbalagens();
    }
}