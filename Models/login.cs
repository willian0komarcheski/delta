using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace loja1.Models
{
    public class login
    {
        [Key]
        public int loginId { get; set; }
        public string? Usarname { get; set; }
        public string? Password { get; set; }
    }
}
