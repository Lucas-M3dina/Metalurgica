using Data.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Interfaces
{
    public interface ILmEmbalagemService
    {

        /// <summary>
        /// Lista todos os embalagem
        /// </summary>
        /// <returns>Uma lista de embalagem</returns>
        List<LmEmbalagem> ConsultaTodos();

        /// <summary>
        /// Atualiza um embalagem existente
        /// </summary>
        /// <param name="id">ID da embalagem que será atualizado</param>
        /// <param name="embalagemAtualizado">Objeto com as novas informações</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Atualiza(int id, EmbalagemViewModel embalagemAtualizado, string responsavel);

        /// <summary>
        /// Deleta uma embalagem existente
        /// </summary>
        /// <param name="id">ID da embalagem que será deletado</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Exclui(int id, string responsavel);

        /// <summary>
        /// Busca uma embalagem através do ID
        /// </summary>
        /// <param name="id">ID da embalagem que será buscada</param>
        /// <returns>Uma embalagem buscado</returns>
        LmEmbalagem ConsultaPorID(int id);

        /// <summary>
        /// Cadastra uma embalagem
        /// </summary>
        /// <param name="embalagem">embalagem que será cadastrada</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        public void Insere(EmbalagemViewModel embalagem, string responsavel);
    }
}
