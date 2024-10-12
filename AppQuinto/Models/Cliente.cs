using System.ComponentModel.DataAnnotations;

namespace AppQuinto.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int? IdCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string NomeCli { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo telefone é obrigatorio")]
        
        public ulong Telefone { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
    }
}
