using System;
using System.Collections.Generic;
using System.Linq;


namespace Gestion_de_Films
{
     public class Administrateur : Utilisateur
    {
     public Administrateur(string nom, string email, string motDePasse)
    : base(nom, email, motDePasse, "Admin") // Ajout du role "Admin"
        {
        }

        public void AjouterFilm(CollectionDeFilms collection, FilmDVD film)
        {
            collection.AjouterFilm(film);
        }

        public void SupprimerFilm(CollectionDeFilms collection, FilmDVD film)
        {
            collection.SupprimerFilm(film);
        }

        public void ModifierFilm(FilmDVD film, int nbCopies)
        {
            film.ModifierNbCopies(nbCopies);
        }

        public void AfficherFilmsEmpruntesParClients(List<Utilisateur> utilisateurs)
        {
            Console.WriteLine("\nFilms empruntés par chaque client:");

            foreach (var utilisateur in utilisateurs.OfType<Client>()) // Filter only clients
            {
                Console.WriteLine($"\nClient: {utilisateur.Nom}");
                utilisateur.AfficherFilmsEmpruntes(); // Use Client's method
            }
        }

    }

}
