using System.ComponentModel.DataAnnotations;

namespace Metalurgica.Entities.Request
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            
        }
        public LoginRequest(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        [Required(ErrorMessage = "O endereço de email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }
    }
}
