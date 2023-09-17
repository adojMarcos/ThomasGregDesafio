namespace Cadastro.Core.Entities
{
    public class Logradouro
    {
        public Guid IdGuid { get; set; }
        public string LogradouroNome { get; set; } = string.Empty;
        public Guid IdCliente { get; set; }
    }
}
