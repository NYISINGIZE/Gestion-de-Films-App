using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class Client : Utilisateur
    {
         List<FilmDVD> FilmsEmpruntes { get;  set; } = new List<FilmDVD>();

        public Client(string nom, string email, string motDePasse)
      : base(nom, email, motDePasse, "Client") // Definir "Client"
        {
        }
        void LouerFilm(FilmDVD film)
        {
            if (film.NbCopiesDisponibles > 0)
            {
                FilmsEmpruntes.Add(film);
                film.NbCopiesDisponibles--;
                Console.WriteLine($"{film.Titre} has been rented.");
            }
            else
            {
                Console.WriteLine("No copies available for rent.");
            }
        }

        public void AfficherFilmsEmpruntes()
        {
            foreach (var film in FilmsEmpruntes)
            {
                film.AfficherDetails();
            }
        }
    }

}
