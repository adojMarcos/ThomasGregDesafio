using System.ComponentModel.DataAnnotations;

namespace Cadastro.WebApp.Models
{
    public class Cliente
    {
        [Display(Name = "Id")]
        public Guid IdGuid { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();
    }
}
