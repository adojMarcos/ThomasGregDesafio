namespace Cadastro.Application.Response
{
    public class ClienteResponse
    {
        public Guid IdGuid { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
