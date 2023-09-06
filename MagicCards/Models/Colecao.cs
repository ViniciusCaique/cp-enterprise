using System.ComponentModel.DataAnnotations;

namespace MagicCards.Models
{
    public class Colecao
    {
        [Key]
        public int ColecaoId { get; set; }
        public string Nome { get; set; }
        
        public DateTime Ano { get; set; }

        public String LogoUrl { get; set; }

        public virtual ICollection<Carta> Cartas { get; set; }

    }
}
