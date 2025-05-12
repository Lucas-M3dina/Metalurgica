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
    public class CertificadoWebService(HttpClient client, IJSRuntime jsRuntime, JsonSerializerOptions jsonOptions) : BaseWebService(client, jsRuntime, jsonOptions)
    {
        private readonly string _rota = "/certificados";

        public async Task<IEnumerable<CertificatesListResponse>> ListAllCertificados()
        {
            var response =  await RealizarRequest<IEnumerable<CertificatesListResponse>>(HttpMethod.Get, _rota);
            return response?.Data ?? [];
        }

        public async Task<CertificateDocumentResponse> DownloadCertificado(int idCertificado)
        {
            var response = await RealizarRequest<CertificateDocumentResponse>(HttpMethod.Get, $"{_rota}/{idCertificado}");
            return response?.Data;
        }

        public async Task<Retorno<object>> CreateCertificado(CertificateRequest request)
        {
            return await RealizarRequest<object>(HttpMethod.Post, _rota, request);
        }

    }
}
