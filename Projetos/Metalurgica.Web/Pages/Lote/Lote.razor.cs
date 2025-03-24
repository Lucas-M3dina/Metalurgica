using Metalurgica.Web.Pages.Produto;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;
using System.Collections.Generic;
using Metalurgica.Web.Services;

namespace Metalurgica.Web.Pages.Lote
{
    public partial class Lote : ComponentBase
    {
        [Inject]
        private IDialogService Dialog { get; set; }
        [Inject]
        private LoteWebService LoteWebService { get; set; }
        private string Search { get; set; } = string.Empty;
        private IEnumerable<LoteFilterResponse> Lotes { get; set; } = [];
        private LoteFilterResponse? LoteSelecionado { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ListByFilter();
        }

        private async Task OpenDialogAsync()
        {
            DialogOptions options = new()
            {
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true,
            };

            IDialogReference dialogReference = await Dialog.ShowAsync<LoteDialog>(string.Empty, options);

            DialogResult result = await dialogReference.Result;
            await ListByFilter();
        }
        private async Task ListByFilter()
        {
            Lotes = await LoteWebService.ListLotesByFilter(Search);
            StateHasChanged();
        }
        
        private async Task SelecionarLote(LoteFilterResponse loteSelecionado)
        {
            LoteSelecionado = loteSelecionado;
        }


    }
}
