using Metalurgica.Web.Pages.Produto;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Metalurgica.Web.Pages.Lote
{
    public partial class Lote : ComponentBase
    {
        [Inject]
        private IDialogService Dialog { get; set; }

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
            //await ListProducts();

        }
    }
}
