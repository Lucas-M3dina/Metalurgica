using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using Entities;
using Entities.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Services
{
    public class LmProdutoService : ILmProdutoService
    {

        private readonly LmProdutoInfra ctx;

        public LmProdutoService(LmProdutoInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmProdutoService()
        {
            this.ctx = new LmProdutoInfra();
        }

        public List<LmProduto> ConsultaTodos()
        {

            return ctx.Listar().Where(e => e.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, ProdutoViewModel elementoAtualizado, string responsavel)
        {

            var produtoBuscado = ConsultaPorID(id);

            produtoBuscado.NmNome = elementoAtualizado.NmNome;
            produtoBuscado.IdElemento = elementoAtualizado.IdElemento;


            ctx.Editar(produtoBuscado, responsavel);
            ctx.Commit();

        }

        public LmProduto ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdProduto == id);
        }


        public void Exclui(int id, string responsavel)
        {
            ctx.Remover(id, responsavel);
            ctx.Commit();
        }

        public void Insere(ProdutoViewModel produto, string responsavel)
        {
            LmProduto produtoBuscado = new();

            produtoBuscado.NmNome = produto.NmNome;
            produtoBuscado.IdElemento = produto.IdElemento;

            ctx.Adicionar(produtoBuscado, responsavel);
            ctx.Commit();
        }

    }
}
