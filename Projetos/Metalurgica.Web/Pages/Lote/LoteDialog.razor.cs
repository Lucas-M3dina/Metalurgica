using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Metalurgica.Web.Pages.Lote
{
    public partial class LoteDialog : ComponentBase
    {
        [CascadingParameter]
        private IMudDialogInstance _MudDialog { get; set; }
        [Inject]
        private LoteWebService LoteWebService { get; set; }

        public LoteRequest Lote { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
           
        }

        private void Submit() => _MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => _MudDialog.Cancel();

        private async Task HandleValidSubmit()
        {
            var retorno = await LoteWebService.CreateLote(Lote);
            Submit();
        }
    }
}
