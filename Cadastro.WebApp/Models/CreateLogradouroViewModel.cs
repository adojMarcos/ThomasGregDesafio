namespace Cadastro.WebApp.Models
{
    public class CreateLogradouroViewModel
    {
        public string LogradouroNome { get; set; } = string.Empty;
        public List<Cliente> Clientes { get; set; }

        public CreateLogradouroViewModel(List<Cliente> clientes)
        {
            Clientes = clientes;
        }
    }
}
