using Data.Models;
using Entities;
using Entities.Lote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Interfaces
{
    public interface ILmLoteService
    {

        /// <summary>
        /// Lista todos os lote
        /// </summary>
        /// <returns>Uma lista de lote</returns>
        List<LmLote> ConsultaTodos();

        /// <summary>
        /// Atualiza um lote existente
        /// </summary>
        /// <param name="id">ID da lote que será atualizado</param>
        /// <param name="loteAtualizado">Objeto com as novas informações</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Atualiza(int id, LoteViewModel loteAtualizado, string responsavel);

        /// <summary>
        /// Deleta uma lote existente
        /// </summary>
        /// <param name="id">ID da lote que será deletado</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Exclui(int id, string responsavel);

        /// <summary>
        /// Busca uma lote através do ID
        /// </summary>
        /// <param name="id">ID da lote que será buscada</param>
        /// <returns>Uma lote buscado</returns>
        LmLote ConsultaPorID(int id);

        /// <summary>
        /// Cadastra uma lote
        /// </summary>
        /// <param name="lote">lote que será cadastrada</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        public void Insere(LoteViewModel lote, string responsavel);
    }
}
