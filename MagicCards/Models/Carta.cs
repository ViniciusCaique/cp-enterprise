using System.ComponentModel.DataAnnotations;

namespace MagicCards.Models
{
    public class Carta
    {
        [Key]
        public int CartaId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string FotoUrl { get; set; }

        public virtual Colecao Colecao { get; set; }    

        public virtual Ilustrador Ilustrador { get; set; }

    }
}
