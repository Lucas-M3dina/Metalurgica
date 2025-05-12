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
    public class LoteWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/lotes";

        public async Task<IEnumerable<LoteFilterResponse>> ListLotesByFilter(string search)
        {
            var retorno = await RealizarRequest<IEnumerable<LoteFilterResponse>>(HttpMethod.Get, $"{_rota}?filter={search}");
            return retorno.Data ?? [];
        }
        
        public async Task<IEnumerable<LoteSelectResponse>> ListLotesToSelect()
        {
            var retorno = await RealizarRequest<IEnumerable<LoteSelectResponse>>(HttpMethod.Get, $"{_rota}/select");
            return retorno.Data ?? [];
        }

        public async Task<Retorno<object>> CreateLote(LoteRequest request)
        {
            return await RealizarRequest<object>(HttpMethod.Post, _rota, request);
        }
    }
}
