using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Retorno<IEnumerable<ProdutoListResponse>>> ListProductsFilter();
        Task<Retorno<object>> CreateProduct(ProdutoRequest product);
        Task<Retorno<IEnumerable<ProdutoSelectResponse>>> ListProductsSelect();
    }
}