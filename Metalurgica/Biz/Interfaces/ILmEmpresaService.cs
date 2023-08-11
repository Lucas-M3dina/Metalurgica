using Data.Models;
using Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Interfaces
{
    public interface ILmEmpresaService
    {

        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>Uma lista de empresas</returns>
        List<LmEmpresa> ConsultaTodos();

        /// <summary>
        /// Atualiza um empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        void Atualiza(int id, LmEmpresa empresaAtualizado);

        /// <summary>
        /// Deleta uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será deletado</param>
        void Exclui(int id);

        /// <summary>
        /// Busca uma empresa através do ID
        /// </summary>
        /// <param name="id">ID da empresa que será buscada</param>
        /// <returns>Uma empresa buscado</returns>
        LmEmpresa ConsultaPorID(int id);

        /// <summary>
        /// Cadastra uma empresa
        /// </summary>
        /// <param name="empresa">empresa que será cadastrada</param>
        public void Insere(LmEmpresa empresa, string responsavel);

    }
}
