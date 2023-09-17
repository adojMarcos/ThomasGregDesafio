using System.ComponentModel.DataAnnotations;

namespace Cadastro.WebApp.Models
{
    public class Logradouro
    {
        [Display(Name = "Id")]
        public Guid IdGuid { get; set; }
        [Display(Name = "Logradouro")]

        public string LogradouroNome { get; set; } = string.Empty;
        public Guid IdClient { get; set; }
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        [Display(Name = "Cliente")]

        public string ClienteName { get; set; } = string.Empty;


    }
}
