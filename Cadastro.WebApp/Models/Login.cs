namespace Cadastro.WebApp.Models
{
    public class Login
    {
        public string Email { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public bool KeepLoggedIn { get; set; }
    }
}
