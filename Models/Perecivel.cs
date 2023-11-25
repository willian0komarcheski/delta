using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Perecivel
    {
    [Key]
    public int PereciveisId { get; set; }
    public string Nome { get; set; }
    public string DataFabricação { get; set; }
    public string DataValidade { get; set; }
    public double preco {  get; set; }
    public int Quantidade { get; set; }
    }
}
