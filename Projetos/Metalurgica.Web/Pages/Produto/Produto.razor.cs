using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metalurgica.Web.Pages.Produto
{
    public partial class Produto : ComponentBase
    {
        [Inject]
        private ProductWebService ProductWebService { get; set; }
        [Inject]
        private IDialogService Dialog { get; set; }

        public IEnumerable<ProdutoListResponse> Products { get; set; }
        public string Pesquisa { get; set; } = string.Empty;


        protected override async Task OnInitializedAsync()
        {
            await ListProducts();
        }

        private async Task ListProducts()
        {
            var productsResponse = await ProductWebService.ListAllProducts();
            Products = productsResponse.Data ?? [];
        }

        private async Task OpenDialogAsync()
        {
            DialogOptions options = new()
            {
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true,
            };

            IDialogReference dialogReference = await Dialog.ShowAsync<ProdutoDialog>(string.Empty, options);

            DialogResult result = await dialogReference.Result;
            await ListProducts();

        }

    }
}
