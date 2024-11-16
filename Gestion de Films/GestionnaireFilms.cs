using System;
using System.Collections.Generic;
using System.Linq;


namespace Gestion_de_Films
{
    public class GestionnaireFilms
    {

        private List<Film> films;

        public GestionnaireFilms(List<Film> films)
        {
            this.films = films;
        }

        // Method to search films by title
        public List<Film> RechercherParTitre(string titre)
        {
            return films.Where(f => f.Titre.IndexOf(titre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }


    }
}
