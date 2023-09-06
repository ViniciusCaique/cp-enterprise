using System.ComponentModel.DataAnnotations;

namespace MagicCards.Models
{
    public class Ilustrador
    {
        [Key]
        public int IlustradorId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Carta> Cartas { get; set; }

    }
}
