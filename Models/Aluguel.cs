using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Aluguel
    {
    [Key]
    public int AluguelId { get; set; }
    public string Nome { get; set; }
    public int Dias_Alugado { get; set; }
    public double Preco_Dia { get; set; }
    }
}
