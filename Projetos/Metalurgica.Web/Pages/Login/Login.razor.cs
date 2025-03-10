using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Metalurgica.Web.Pages.Login
{
    public partial class Login : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private LoginWebService LoginWebService { get; set; }

        public LoginRequest usuario = new();
        private string mensagemErro = string.Empty;

        private async Task HandleValidSubmit()
        {
            Retorno<LoginResponse> response = await LoginWebService.EfetuarLogin(usuario);

            if (response.Success)
            {
                NavigationManager.NavigateTo("/produto", true);
                return;
            }

            mensagemErro = "Algo deu errado";
        }
    }
}
