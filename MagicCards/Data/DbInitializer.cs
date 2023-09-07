using MagicCards.Models;

namespace MagicCards.Data
{
    public class DbInitializer
    {

        public static void Initizalize(MagicDbContext context) { 
            context.Database.EnsureCreated();

            if (context.Cartas.Any()) {
                return;
            }

            var cartas = new Carta[] {

             new Carta{Nome="AAA", Tipo="sss", Descricao="asd", FotoUrl="https://upload.wikimedia.org/wikipedia/en/thumb/a/aa/Magic_the_gathering-card_back.jpg/220px-Magic_the_gathering-card_back.jpg" } 
             };

            foreach (var carta in cartas) 
            {
                context.Cartas.Add(carta);
            }
            context.SaveChanges();
        }
    }
}
