using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        [Required]
        public string Status { get; set; } = "Indisponivel";

        [Required]
        [Range(0, double.MaxValue)]
        public double Preco { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int QuantidadeEstoque { get; set; }

    }
}
