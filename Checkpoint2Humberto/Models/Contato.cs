using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2Humberto.Models
{
    [Table("tb_contato")]
    public class Contato
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter max de 100 caracteres")]
        public string nome { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O telefone do contato deve ter no máximo 20 caracteres.")]
        public string telefone { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O email do contato deve ter no máximo 100 caracteres.")]
        public string email { get; set; } = string.Empty;   


    }
}
