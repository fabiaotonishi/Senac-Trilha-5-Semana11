using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Dtos
{
    public class CadastroProdutoDto
    {
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo Nome é de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é Obrigatório")]
        [MaxLength(500, ErrorMessage = "O tamanho máximo do campo Descrição é de 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é Obrigatório")]
        public double PrecoUnitario { get; set; }

        [Required(ErrorMessage = "A Quantidade é Obrigatório")]
        public int Quantidade { get; set; }
    }
}
