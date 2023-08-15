﻿using BCrypt.Net;
using Biz.Infra;
using Biz.Interfaces;
using Data.Models;
using Entities.Usuario;

namespace Biz.Services
{
    public class LmUsuarioService : ILmUsuarioService
    {

        private readonly LmUsuarioInfra ctx;

        public LmUsuarioService(LmUsuarioInfra ctx)
        {
            this.ctx = ctx;
        }

        public LmUsuarioService()
        {
            this.ctx = new LmUsuarioInfra();
        }

        public List<LmUsuario> ConsultaTodos()
        {
            return ctx.Listar().Where(u => u.FlAtivo == true).ToList();
        }

        public void Atualiza(int id, LmUsuario usuarioAtualizado)
        {
            
            var usuarioBuscado = ConsultaPorID(id);
            string responsavel = usuarioBuscado.NmNome;

            if (usuarioAtualizado.DsEmail != null)
            {
                usuarioBuscado.DsEmail = usuarioAtualizado.DsEmail;
            }

            if (usuarioAtualizado.DsSenha != null)

            {
                usuarioBuscado.DsSenha = BCrypt.Net.BCrypt.HashPassword(usuarioAtualizado.DsSenha);
            }

            if (usuarioAtualizado.NmNome != null)
            {
                usuarioBuscado.NmNome = usuarioAtualizado.NmNome;
            }

            ctx.Editar(usuarioBuscado, responsavel);
            ctx.Commit();

        }

        public LmUsuario ConsultaPorID(int id)
        {
            return ctx.ObterPor(u => u.IdUsuario == id);
        }

        public UsuarioViewModel GetMe(int id)
        {
            var usuarioBuscado = ctx.ObterPor(u => u.IdUsuario == id);
            UsuarioViewModel usuario = new();
            usuario.IdTipoUsuario = usuarioBuscado.IdTipoUsuario;
            usuario.nome = usuarioBuscado.NmNome;
            usuario.email = usuarioBuscado.DsEmail;

            return usuario;
        }


        public void Exclui(int id)
        {
            var user = ConsultaPorID(id);

            ctx.Remover(id, user.NmNome);
            ctx.Commit();
        }

        public void Insere(LmUsuario user, string responsavel)
        {
            user.DsSenha = BCrypt.Net.BCrypt.HashPassword(user.DsSenha); 
            ctx.Adicionar(user, responsavel); 
            ctx.Commit();
        }

        public LmUsuario Login(UsuarioLoginViewModel user)
        {
            LmUsuario usuario = ctx.ObterPor(u => u.DsEmail == user.email);
            if (usuario != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.senha, usuario.DsSenha))
                {
                    return usuario;
                }
            }
            return null;

        }

    }
}
