using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Carro
    {
    [Key]
    public int CarroId { get; set; }
    public string Name { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Ano { get; set; }
    public double Preco { get; set; }
    public string Tipo { get; set; }
    }
}
