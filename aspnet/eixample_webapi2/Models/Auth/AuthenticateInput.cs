namespace eixample_webapi2.Host.Models.Auth
{
    public class AuthenticateInput
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
