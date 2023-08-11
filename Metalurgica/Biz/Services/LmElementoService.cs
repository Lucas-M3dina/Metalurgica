using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using Entities.Elemento;
using Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Services
{
    public class LmElementoService : ILmElementoService
    {

        private readonly LmElementoInfra ctx;

        public LmElementoService(LmElementoInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmElementoService()
        {
            this.ctx = new LmElementoInfra();
        }

        public List<LmElemento> ConsultaTodos()
        {

            return ctx.Listar().Where(e => e.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, ElementoViewModel elementoAtualizado, string responsavel)
        {

            var elementoBuscado = ConsultaPorID(id);

            elementoBuscado.NmNome = elementoAtualizado.NmNome;
            elementoBuscado.DsEspecificacao = elementoAtualizado.DsEspecificacao;
            elementoBuscado.DsAstm = elementoAtualizado.DsAstm;


            ctx.Editar(elementoBuscado, responsavel);

        }

        public LmElemento ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdElemento == id);
        }


        public void Exclui(int id, string responsavel)
        {
            ctx.Remover(id, responsavel);
            ctx.Commit();
        }

        public void Insere(ElementoViewModel elemento, string responsavel)
        {
            LmElemento elementoBuscado = new();

            elementoBuscado.NmNome = elemento.NmNome;
            elementoBuscado.DsEspecificacao = elemento.DsEspecificacao;
            elementoBuscado.DsAstm = elemento.DsAstm;

            ctx.Adicionar(elementoBuscado, responsavel);
            ctx.Commit();
        }

    }
}
