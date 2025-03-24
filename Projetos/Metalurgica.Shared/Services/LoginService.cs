using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Services.Interfaces;
using Metalurgica.Shared.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Metalurgica.Shared.Services
{
    public class LoginService(IConfiguration configuration, IUsuarioRepository usuariosRepository) : ILoginService
    {
        public async Task<Retorno<LoginResponse>> Logar(LoginRequest dadosLogin)
        {
            string erroGenerico = "Usuario ou senha incorretos";
            Usuario usuarioLogado = await usuariosRepository.BuscarPorAsync(x => x.Ds_Email == dadosLogin.Email);
            if (usuarioLogado == null)
                return new Retorno<LoginResponse>(false, HttpStatusCode.Unauthorized, erroGenerico);

            bool isValido = Criptografia.ValidarSenha(dadosLogin.Senha, usuarioLogado.Ds_Senha);
            if (!isValido)
                return new Retorno<LoginResponse>(false, HttpStatusCode.Unauthorized, erroGenerico);

            LoginResponse response = new(
                token: GenerateJwtToken(usuarioLogado)
            );

            return new Retorno<LoginResponse>(true, "Logado com sucesso", response, HttpStatusCode.OK);
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            IConfigurationSection jwtSettings = configuration.GetSection("Jwt");

            Claim[] claims =
            [
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id_Usuario.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Ds_Nome.ToString()),
                new Claim("cargo", usuario.Id_Cargo.ToString()),
                new Claim("email", usuario.Ds_Email.ToString())
            ];

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            SigningCredentials credenciais = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
