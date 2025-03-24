using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface ILoteService
    {
        Task<Retorno<object>> CreateLote(LoteRequest lote);
    }
}