using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComexAPI.Models
{
    public class Cliente
    {
        //pk
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //fk
        public int EnderecoId { get; set; }
        [ForeignKey(nameof(EnderecoId))]
        public virtual Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo Nome é de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A profissao é obrigatório")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }



    }
}
