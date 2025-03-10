using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Metalurgica.Web.Services
{
    public class QuesitoWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/quesitos";

        public async Task<Retorno<IEnumerable<QuesitoResponse>>> ListAllQuesitos()
        {
            return await RealizarRequest<IEnumerable<QuesitoResponse>>(HttpMethod.Get, _rota);
        }
    }
}
