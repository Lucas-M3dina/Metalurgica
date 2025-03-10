using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Metalurgica.Web.Services
{
    public class EmbalagemWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/embalagens";

        public async Task<Retorno<IEnumerable<EmbalagemResponse>>> ListAllEmbalagens()
        {
            return await RealizarRequest<IEnumerable<EmbalagemResponse>>(HttpMethod.Get, _rota);
        }
    }
}
