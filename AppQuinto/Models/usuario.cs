using System.ComponentModel.DataAnnotations;

namespace AppQuinto.Models
{
    public class usuario
    {
        [Display(Name = "Código")]
        public int? IdUsu { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage ="O campo nome é obrigatorio")]
        public string nomeUsu { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo cargo é obrigatorio")]
        public string Cargo { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }
    }
}
