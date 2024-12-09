using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.DTOs
{
    public class InserirProduto
    {

        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Preco { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int QuantidadeEstoque { get; set; }
    }
}
