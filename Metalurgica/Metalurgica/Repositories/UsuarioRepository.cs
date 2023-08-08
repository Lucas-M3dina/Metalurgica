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
            if (ctx == null)
            {
                Console.WriteLine("TA NULOOOOOOOOOOOOOOOOOOOOOO");
            }
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
                user.DsSenha = usuarioAtualizado.DsSenha;
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


    }
}