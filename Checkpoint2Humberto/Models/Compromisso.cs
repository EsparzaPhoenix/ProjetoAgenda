using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint2Humberto.Models
{
    [Table("tb_compromisso")]
    public class Compromisso
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O local do compromisso é obrigatório.")]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória.")]
        public string Data { get; set; } = string.Empty;


    }
}
