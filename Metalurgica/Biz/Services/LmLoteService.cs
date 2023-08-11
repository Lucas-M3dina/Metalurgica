using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using Entities;
using Entities.Lote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Services
{
    public class LmLoteService : ILmLoteService
    {

        private readonly LmLoteInfra ctx;

        public LmLoteService(LmLoteInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmLoteService()
        {
            this.ctx = new LmLoteInfra();
        }

        public List<LmLote> ConsultaTodos()
        {

            return ctx.Listar().Where(e => e.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, LoteViewModel  loteAtualizado, string responsavel)
        {

            var LmLoteBuscado = ConsultaPorID(id);

            LmLoteBuscado.IdEmbalagem = loteAtualizado.IdEmbalagem;
            LmLoteBuscado.IdProduto = loteAtualizado.IdProduto;


            ctx.Editar(LmLoteBuscado, responsavel);
            ctx.Commit();

        }

        public LmLote ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdEmbalagem == id);
        }


        public void Exclui(int id, string responsavel)
        {
            ctx.Remover(id, responsavel);
            ctx.Commit();
        }

        public void Insere(LoteViewModel lote, string responsavel)
        {
            LmLote LmLoteBuscado = new();

            LmLoteBuscado.IdEmbalagem = lote.IdEmbalagem;
            LmLoteBuscado.IdProduto = lote.IdProduto;

            ctx.Adicionar(LmLoteBuscado, responsavel);
            ctx.Commit();
        }
    }
}
