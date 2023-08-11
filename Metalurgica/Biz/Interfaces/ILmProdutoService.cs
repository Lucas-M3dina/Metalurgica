using Data.Models;
using Entities;
using Entities.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Interfaces
{
    public interface ILmProdutoService
    {

        /// <summary>
        /// Lista todos os produto
        /// </summary>
        /// <returns>Uma lista de produto</returns>
        List<LmProduto> ConsultaTodos();

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="id">ID da produto que será atualizado</param>
        /// <param name="produtoAtualizado">Objeto com as novas informações</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Atualiza(int id, ProdutoViewModel produtoAtualizado, string responsavel);

        /// <summary>
        /// Deleta uma produto existente
        /// </summary>
        /// <param name="id">ID da produto que será deletado</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Exclui(int id, string responsavel);

        /// <summary>
        /// Busca uma produto através do ID
        /// </summary>
        /// <param name="id">ID da produto que será buscada</param>
        /// <returns>Uma produto buscado</returns>
        LmProduto ConsultaPorID(int id);

        /// <summary>
        /// Cadastra uma produto
        /// </summary>
        /// <param name="produto">produto que será cadastrada</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        public void Insere(ProdutoViewModel produto, string responsavel);
    }
}
