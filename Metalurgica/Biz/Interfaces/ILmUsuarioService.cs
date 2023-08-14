using Data.Models;
using Entities.Usuario;

namespace Biz.Interfaces
{
    public interface ILmUsuarioService
    {

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<LmUsuario> ConsultaTodos();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualiza(int id, LmUsuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Exclui(int id);

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        LmUsuario ConsultaPorID(int id);

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="user">usuário que será cadastrado</param>
        /// <returns>Um usuário cadastrado</returns>
        public void Insere(LmUsuario user, string responsavel);


        /// <summary>
        /// Faz login na aplicação
        /// </summary>
        /// <param name="user">usuário que será comparado com o do banco</param>
        /// <returns>O usuario correspondente a senha email</returns>
        public LmUsuario Login(UsuarioLoginViewModel user);


        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado com dados filtrados</returns>
        public UsuarioViewModel GetMe(int id);
    }


}
