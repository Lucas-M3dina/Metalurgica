using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Pages.Produto;
using Metalurgica.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace Metalurgica.Web.Pages.Certificado
{
    public partial class Certificado : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject]
        public CertificadoWebService CertificadoWebService { get; set; }
        [Inject]
        private IDialogService Dialog { get; set; }
        [Inject]
        private NavigationManager Nav { get; set; }
        [Inject]
        private IJSRuntime JS { get; set; }

        public IEnumerable<CertificatesListResponse> Certificates { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await ListCertificates();
        }

        private async Task Download(int idCertificado){
            var fileResponse = await CertificadoWebService.DownloadCertificado(idCertificado);
            using var ms = new MemoryStream(fileResponse.Arquivo);

            using var streamRef = new DotNetStreamReference(stream: ms);

            await JS.InvokeVoidAsync(
              "downloadFileFromStream",
              streamRef,
              fileResponse.Filename,
              fileResponse.Type
            );
        }

        private async Task ListCertificates()
        {
            Certificates = await CertificadoWebService.ListAllCertificados();
        }

        private async Task OpenDialogAsync()
        {
            DialogOptions options = new()
            {
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true,
            };

            IDialogReference dialogReference = await Dialog.ShowAsync<CertificadoDialog>(string.Empty, options);

            DialogResult result = await dialogReference.Result;
            await ListCertificates();

        }

    }
}
