using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    using System;

    public class Pret
    {
        public Client Client { get; set; }
         FilmDVD FilmEmprunte { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }

        public void AfficherPret()
        {
            Console.WriteLine($"Client: {Client.Nom}, Film: {FilmEmprunte.Titre}, Date Emprunt: {DateEmprunt}, Date Retour: {DateRetour}");
        }
    }

}
