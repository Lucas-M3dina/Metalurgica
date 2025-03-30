using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Metalurgica.Web.Services
{
    public class ProductWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/produtos";

        public async Task<Retorno<IEnumerable<ProdutoListResponse>>> ListAllProducts()
        {
            return await RealizarRequest<IEnumerable<ProdutoListResponse>>(HttpMethod.Get, $"{_rota}/filter");
        }

        public async Task<IEnumerable<ProdutoSelectResponse>> ListProductSelect()
        {
            var retorno =  await RealizarRequest<List<ProdutoSelectResponse>>(HttpMethod.Get, _rota);
            return retorno?.Data ?? [];
        }

        public async Task<Retorno<object>> CreateProduct(ProdutoRequest request)
        {
            return await RealizarRequest<object>(HttpMethod.Post, _rota, request);
        }
    }
}
