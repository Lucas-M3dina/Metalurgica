using Microsoft.JSInterop;
using System.Text.Json;
using System.Text;
using Metalurgica.Entities.Common;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Metalurgica.Entities.Response;

namespace Metalurgica.Web.Services
{
    public abstract class BaseWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions)
    {
        private readonly HttpClient _client = client;
        private readonly IJSRuntime _jsRuntime = jsRuntime;
        private readonly JsonSerializerOptions _jsonOptions = jsonOptions;

        public async Task<Retorno<T>> RealizarRequest<T>(HttpMethod metodo, string caminho, object? data = null)
        {
            try
            {
                HttpRequestMessage requestMessage = new(metodo, _client.BaseAddress + caminho);
                string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

                if (!string.IsNullOrEmpty(token))
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                if (data != null && (metodo == HttpMethod.Post || metodo == HttpMethod.Put || metodo == HttpMethod.Patch))
                {
                    StringContent jsonContent = new(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                    requestMessage.Content = jsonContent;
                }

                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    return new Retorno<T>(false, "Algo deu errado");
                }

                string corpoJsonResponse = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(corpoJsonResponse))
                    return new Retorno<T>(true, null);

                return JsonSerializer.Deserialize<Retorno<T>>(corpoJsonResponse, _jsonOptions);

            }
            catch(Exception ex)
            {
                return new Retorno<T>(false, "Algo deu errado");
            }
        }
    }
}
