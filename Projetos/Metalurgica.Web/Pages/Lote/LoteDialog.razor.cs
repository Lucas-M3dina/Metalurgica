using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;

namespace Metalurgica.Web.Pages.Lote
{
    public partial class LoteDialog : ComponentBase
    {
        [CascadingParameter]
        private IMudDialogInstance _MudDialog { get; set; }
        [Inject]
        private LoteWebService LoteWebService { get; set; }
        [Inject]
        private ProductWebService ProductWebService { get; set; }
        [Inject]
        private QuesitoWebService QuesitoWebService { get; set; }

        public LoteRequest Lote { get; set; } = new() { IdProduto = 1 };
        public IEnumerable<ProdutoSelectResponse> Produtos { get; set; } = [];
        public IEnumerable<QuesitoDataResponse> Quesitos { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await ListProducts();
            await ListQuesitosByIdProduct();
        }

        private void Submit() => _MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => _MudDialog.Cancel();

        private async Task HandleValidSubmit()
        {
            var retorno = await LoteWebService.CreateLote(Lote);
            Submit();
        }
        
        private async Task ListProducts()
        {
            Produtos = await ProductWebService.ListProductSelect();
            var produto = Produtos.FirstOrDefault();
            if (produto != null)
            {
                Lote.IdProduto = produto.IdProduto;
            }
            StateHasChanged();
        }

        private async Task ListQuesitosByIdProduct()
        {
            Quesitos = await QuesitoWebService.ListAllQuesitosByProductId(Lote.IdProduto);
            StateHasChanged();
        }


    }
}
