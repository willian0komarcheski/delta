using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public virtual ICollection<carrinho> carrinho { get;}
    }
}