using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metalurgica.Web.Pages.Produto
{
    public partial class ProdutoDialog : ComponentBase
    {
        [CascadingParameter]
        private IMudDialogInstance _MudDialog { get; set; }
        [Inject]
        private EmbalagemWebService _EmbalagemWebService { get; set; }
        [Inject]
        private QuesitoWebService _QuesitoWebService { get; set; }
        [Inject]
        private ProductWebService _ProductWebService { get; set; }

        public IEnumerable<EmbalagemResponse> embalagens { get; set; } 
        public IEnumerable<QuesitoResponse> Quesitos { get; set; } 
        public ProdutoRequest Product { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await ListAllEmbalagens();
            await ListAllQuesitos();
            AddEmbalagem();
            AddQuesito();
        }

        private void Submit() => _MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => _MudDialog.Cancel();

        
        private void AddEmbalagem() => Product.Embalagens.Add(new EmbalagemRequest(embalagens.FirstOrDefault().IdEmbalagem));

        private void RemoveEmbalagem(EmbalagemRequest embalagemRequest)
        {
            if (Product.Embalagens.Count == 1)
                return;

            Product.Embalagens.Remove(embalagemRequest);
        }

        private async Task ListAllEmbalagens()
        {
            var embalagensResponse = await _EmbalagemWebService.ListAllEmbalagens();
            embalagens = embalagensResponse.Data ?? [];
        }

        private void RemoveQuesito(QuesitoRequest quesitoRequest)
        {
            if (Product.Quesitos.Count == 1)
                return;

            Product.Quesitos.Remove(quesitoRequest);
        }

        private void AddQuesito() => Product.Quesitos.Add(new QuesitoRequest(Quesitos.FirstOrDefault().IdQuesito));

        private async Task ListAllQuesitos()
        {
            var quesitosResponse = await _QuesitoWebService.ListAllQuesitos();
            Quesitos = quesitosResponse.Data ?? [];
        }

        private async Task HandleValidSubmit()
        {
            var retorno = await _ProductWebService.CreateProduct(Product);
            Submit();
        }
    }
}
