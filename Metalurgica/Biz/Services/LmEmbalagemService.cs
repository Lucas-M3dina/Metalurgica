using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using Entities;
using Entities.Elemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Services
{
    public class LmEmbalagemService : ILmEmbalagemService
    {


        private readonly LmEmbalagemInfra ctx;

        public LmEmbalagemService(LmEmbalagemInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmEmbalagemService()
        {
            this.ctx = new LmEmbalagemInfra();
        }

        public List<LmEmbalagem> ConsultaTodos()
        {

            return ctx.Listar().Where(e => e.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, EmbalagemViewModel elementoAtualizado, string responsavel)
        {

            var LmEmbalagemBuscado = ConsultaPorID(id);

            LmEmbalagemBuscado.NmNome = elementoAtualizado.NmNome;


            ctx.Editar(LmEmbalagemBuscado, responsavel);
            ctx.Commit();

        }

        public LmEmbalagem ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdEmbalagem == id);
        }


        public void Exclui(int id, string responsavel)
        {
            ctx.Remover(id, responsavel);
            ctx.Commit();
        }

        public void Insere(EmbalagemViewModel elemento, string responsavel)
        {
            LmEmbalagem LmEmbalagemBuscado = new();

            LmEmbalagemBuscado.NmNome = elemento.NmNome;

            ctx.Adicionar(LmEmbalagemBuscado, responsavel);
            ctx.Commit();
        }

    }
}
