using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Services
{
    public class LmEmpresaService : ILmEmpresaService
    {
        private readonly LmEmpresaInfra ctx;

        public LmEmpresaService(LmEmpresaInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmEmpresaService()
        {
            this.ctx = new LmEmpresaInfra();
        }

        public List<LmEmpresa> ConsultaTodos()
        {

            return ctx.Listar().Where(e => e.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, LmEmpresa empresaAtualizada)
        {

            var usuarioBuscado = ConsultaPorID(id);
            string responsavel = usuarioBuscado.NmNome;
            

            ctx.Editar(usuarioBuscado, responsavel);

        }

        public LmEmpresa ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdEmpresa == id);
        }


        public void Exclui(int id)
        {
            var empresa = ConsultaPorID(id);

            //Alterar e pegar responsavel do token dps
            ctx.Remover(id, empresa.NmNome);
            ctx.Commit();
        }

        public void Insere(LmEmpresa empresa, string responsavel)
        {
            ctx.Adicionar(empresa, responsavel);
            ctx.Commit();
        }
    }
}
