using Metalurgica.Context;
using Metalurgica.Interfaces;
using Metalurgica.Models;

namespace Metalurgica.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MetalurgicaEstudoContext ctx;

        public UsuarioRepository(MetalurgicaEstudoContext _ctx)
        {
            ctx = _ctx;
        }
        public List<LmUsuario> ConsultaTodos(){
            return ctx.LmUsuarios.ToList();
        }

        public void Atualiza(int id, LmUsuario usuarioAtualizado){
            LmUsuario user = ConsultaPorID(id);

            if (usuarioAtualizado.DsEmail != null)
            {
                user.DsEmail = usuarioAtualizado.DsEmail;
            }

            if (usuarioAtualizado.DsSenha != null)
            {
                user.DsSenha = BCrypt.Net.BCrypt.HashPassword(usuarioAtualizado.DsSenha);
            }

            if (usuarioAtualizado.NmNome != null)
            {
                user.NmNome = usuarioAtualizado.NmNome;
            }

            ctx.LmUsuarios.Update(user);
            ctx.SaveChanges();
        }
    
        public void Insere(LmUsuario user){
            user.DsSenha = BCrypt.Net.BCrypt.HashPassword(user.DsSenha);

            ctx.LmUsuarios.Add(user);
            ctx.SaveChanges();
        }

        public LmUsuario ConsultaPorID(int id){
            return ctx.LmUsuarios.FirstOrDefault(user => user.IdUsuario == id)!;
        }

        public void Exclui(int id){
            LmUsuario usuarioBuscado = ConsultaPorID(id);
            ctx.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public LmUsuario Login( string email, string password)
        {
            var usuario = ctx.LmUsuarios.FirstOrDefault(u => u.DsEmail == email);

            if (usuario != null)
            {
                bool comparando = BCrypt.Net.BCrypt.Verify(password, usuario.DsSenha);
                if (comparando)
                {
                    return usuario;
                }
            }

            return null;
        }


    }
}