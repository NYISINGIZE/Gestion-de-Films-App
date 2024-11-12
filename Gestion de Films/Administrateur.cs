using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       
    }

}
