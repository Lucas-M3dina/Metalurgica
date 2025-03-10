using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Metalurgica.Web.Services
{
    public class LoginWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/login";

        public async Task<Retorno<LoginResponse>> EfetuarLogin(LoginRequest dadosLogin)
        {

            Retorno<LoginResponse> response = await RealizarRequest<LoginResponse>(HttpMethod.Post, _rota, dadosLogin);

            if (response.Success && response.Data != null)
            {
                var loginResponse = response.Data;
                await jsRuntime.InvokeAsync<string>("localStorage.setItem", "token", loginResponse.Token);
            }

            return response;
        }
    }
}
