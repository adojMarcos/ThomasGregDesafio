namespace Cadastro.Core.Entities
{
    public class Cliente
    {
        public Guid IdGuid { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
