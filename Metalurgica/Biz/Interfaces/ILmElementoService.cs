using Data.Models;
using Entities.Elemento;

namespace Biz.Interfaces
{
    public interface ILmElementoService
    {
        /// <summary>
        /// Lista todos os elementos
        /// </summary>
        /// <returns>Uma lista de elementos</returns>
        List<LmElemento> ConsultaTodos();

        /// <summary>
        /// Atualiza um elemento existente
        /// </summary>
        /// <param name="id">ID da elemento que será atualizado</param>
        /// <param name="elementoAtualizado">Objeto com as novas informações</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Atualiza(int id, ElementoViewModel elementoAtualizado, string responsavel);

        /// <summary>
        /// Deleta uma elemento existente
        /// </summary>
        /// <param name="id">ID da elemento que será deletado</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        void Exclui(int id, string responsavel);

        /// <summary>
        /// Busca uma elemento através do ID
        /// </summary>
        /// <param name="id">ID da elemento que será buscada</param>
        /// <returns>Uma elemento buscado</returns>
        LmElemento ConsultaPorID(int id);

        /// <summary>
        /// Cadastra uma elemento
        /// </summary>
        /// <param name="elemento">elemento que será cadastrada</param>
        /// <param name="responsavel">String que identifica usuario logado</param>
        public void Insere(ElementoViewModel elemento, string responsavel);
    }
}
