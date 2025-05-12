using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;
using System;

namespace Metalurgica.Web.Pages.Certificado
{
    public partial class CertificadoDialog : ComponentBase
    {
        [CascadingParameter]
        private IMudDialogInstance _MudDialog { get; set; }
        [Inject]
        private LoteWebService _LoteWebService { get; set; }
        [Inject]
        private CertificadoWebService _CertificadoWebService { get; set; }

        public CertificateRequest Certificate { get; set; } = new();
        public IEnumerable<LoteSelectResponse> LoteSelectResponse { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await ListLotesToSelect();
        }

        private void Submit() => _MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => _MudDialog.Cancel();

        private async Task ListLotesToSelect()
        {
            LoteSelectResponse = await _LoteWebService.ListLotesToSelect();
            var firstLote = LoteSelectResponse.FirstOrDefault();
            Certificate.IdLote = firstLote != null ? firstLote.IdLote : 1;
            StateHasChanged();
        }

        private async Task HandleValidSubmit()
        {
            var retorno = await _CertificadoWebService.CreateCertificado(Certificate);
            Submit();
        }
    }
}



