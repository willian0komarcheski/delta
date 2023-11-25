using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Agranel
    {
    [Key]
    public int AgranelId { get; set; }
    public string Nome { get; set; }
    public double Peso { get; set; }
    public double Preco_Peso { get; set; }
    }
}
