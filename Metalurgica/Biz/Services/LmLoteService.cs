using Biz.Infra;
using Biz.Interfaces;
using Dapper;
using Data.Models;
using Entities;
using Entities.Lote;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public IEnumerable<LoteListagemViewModel> ConsultaTodos()
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=metalurgica_estudo;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                var lote = @"
                SELECT LM_Lote.Id_Lote,LM_Lote.Dt_Cadastro, LM_Lote.Nm_MetodologiaAnaliseGranumetrica, LM_Lote.Ds_observacoes, LM_Produto.Nm_Nome AS NomeProduto, LM_Embalagem.Nm_Nome AS NomeEmbalagem, LM_Empresa.Nm_Nome AS NomeEmpresa FROM LM_Lote 
                INNER JOIN LM_Produto ON LM_Produto.Id_Produto = LM_Lote.Id_Produto
                INNER JOIN LM_Embalagem ON LM_Embalagem.Id_Embalagem = LM_Lote.Id_Embalagem
                INNER JOIN LM_Empresa ON LM_Empresa.Id_Empresa = LM_Lote.Id_Empresa";
                return connection.Query<LoteListagemViewModel>(lote);
            }
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

        public IEnumerable<LoteListagemViewModel> ConsultaDapperId(int id)
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=metalurgica_estudo;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                var lote = @"
                SELECT LM_Lote.Id_Lote,LM_Lote.Dt_Cadastro, LM_Lote.Nm_MetodologiaAnaliseGranumetrica, LM_Lote.Ds_observacoes, LM_Produto.Nm_Nome AS NomeProduto, LM_Embalagem.Nm_Nome AS NomeEmbalagem, LM_Empresa.Nm_Nome AS NomeEmpresa FROM LM_Lote 
                INNER JOIN LM_Produto ON LM_Produto.Id_Produto = LM_Lote.Id_Produto
                INNER JOIN LM_Embalagem ON LM_Embalagem.Id_Embalagem = LM_Lote.Id_Embalagem
                INNER JOIN LM_Empresa ON LM_Empresa.Id_Empresa = LM_Lote.Id_Empresa
                WHERE LM_Lote.Id_Lote = @id
                ";

                

                return connection.Query<LoteListagemViewModel>(lote, new { id = id });
            }
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
            LmLoteBuscado.IdEmpresa = lote.IdEmpresa;
            LmLoteBuscado.NmMetodologiaAnaliseGranumetrica = lote.NmMetodologiaAnaliseGranumetrica;
            LmLoteBuscado.DsObservacoes = lote.DsObservacoes;

            ctx.Adicionar(LmLoteBuscado, responsavel);
            ctx.Commit();
        }
    }
}
