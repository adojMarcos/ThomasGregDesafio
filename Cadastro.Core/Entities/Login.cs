namespace Cadastro.Core.Entities
{
    public class Login
    {
        public Guid IdGuid { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
