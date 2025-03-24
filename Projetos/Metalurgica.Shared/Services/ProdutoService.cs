using Metalurgica.Data;
using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Services.Interfaces;
using System.Dynamic;
using System.Net;

namespace Metalurgica.Shared.Services
{
    public class ProdutoService(
        IProdutoRepository produtoRepository,
        IQuesitoRepository quesitoRepository,
        IProdutoQuesitoRepository produtoQuesitoRepository,
        IProdutoEmbalagemRepository produtoEmbalagemRepository,
        IEmbalagemRepository embalagemRepository
        ) : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;
        private readonly IQuesitoRepository _quesitoRepository = quesitoRepository;
        private readonly IProdutoQuesitoRepository _produtoQuesitoRepository = produtoQuesitoRepository;
        private readonly IProdutoEmbalagemRepository _produtoEmbalagemRepository = produtoEmbalagemRepository;
        private readonly IEmbalagemRepository _embalagemRepository = embalagemRepository;

        public async Task<Retorno<IEnumerable<ProdutoListResponse>>> ListProductsFilter()
        {
            var allProducts = await _produtoRepository.BuscarTodosAsync();

            var productsFilter = allProducts.Select(x => new ProdutoListResponse(
                idProduto: x.Id_Produto,
                nome: x.Ds_Nome,
                editor: x.Ds_Alteracao ?? "Não identificado",
                dataCriacao: x.Dt_Criacao,
                setor: x.Ds_Setor
            ));

            return new Retorno<IEnumerable<ProdutoListResponse>>(true, productsFilter, HttpStatusCode.OK); ;
        }

        public async Task<Retorno<IEnumerable<ProdutoSelectResponse>>> ListProductsSelect()
        {
            var allProducts = await _produtoRepository.BuscarTodosAsync();

            var productsFilter = allProducts.Select(x => new ProdutoSelectResponse(
                idProduto: x.Id_Produto,
                nomeProduto: x.Ds_Nome
            ));

            return new Retorno<IEnumerable<ProdutoSelectResponse>>(true, productsFilter, HttpStatusCode.OK); ;
        }

        public async Task<Retorno<object>> CreateProduct(ProdutoRequest product)
        {
            var productDb = await _produtoRepository.CriarAsync(new Produto()
            {
                Ds_Nome = product.Nome,
                Ds_Descricao = product.Descricao,
                Ds_Especificacao = product.Especificacao,
                Dt_Emissao = product.Emissao ?? DateTime.Now,
                Nr_Validade = product.Validade,
                Nr_Versao = product.Versao,
                Ds_Io = product.Io,
                Ds_Setor = product.Setor,
                Ds_Especie = product.Especie
            });

            foreach (var embalagem in product.Embalagens)
            {
                var produtoEmbalagem = new ProdutoEmbalagem
                {
                    Id_Produto = productDb.Id_Produto,
                    Id_Embalagem = embalagem.IdEmbalagem,
                    Nr_Quantidade = embalagem.Quantidade
                };

                await _produtoEmbalagemRepository.CriarAsync(produtoEmbalagem);
            }

            foreach (var quesito in product.Quesitos)
            {
                var produtoQuesito = new ProdutoQuesito
                {
                    Id_Produto = productDb.Id_Produto,
                    Id_Quesito = quesito.IdQuesito,
                    Vl_Ideal = quesito.Ideal,
                    Vl_Minimo = quesito.Minimo,
                    Vl_Maximo = quesito.Maximo
                };

                await _produtoQuesitoRepository.CriarAsync(produtoQuesito);
            }

            return new Retorno<object>(true, HttpStatusCode.Created);
        }
    }
}
