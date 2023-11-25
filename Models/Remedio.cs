using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Remedio
    {
    [Key]
    public int RemedioId { get; set; }
    public string Nome { get; set; }
    public string Marca { get; set; }
    public bool Receita { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    }
}
