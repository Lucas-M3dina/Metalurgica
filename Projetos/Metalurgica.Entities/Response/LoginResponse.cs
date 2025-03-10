namespace Metalurgica.Entities.Response
{
    public class LoginResponse
    {
        public LoginResponse()
        {
        }

        public LoginResponse(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
