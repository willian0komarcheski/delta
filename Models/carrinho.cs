using loja1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loja1.Models
{
    public class carrinho
    {
        [Key]
        public int carrinhoId { get; set; }
        [Display(Name = "login")]
        public int loginId { get; set; }
        public virtual login login { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public double precototal { get; set; }
    }
}
