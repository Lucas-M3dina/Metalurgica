using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface ILoteService
    {
        Task<Retorno<object>> CreateLote(LoteRequest lote);
        Task<Retorno<IEnumerable<LoteFilterResponse>>> ListLotesByFilter(string filter);
        Task<Retorno<IEnumerable<LoteSelectResponse>>> ListLotesToSelect();
    }
}