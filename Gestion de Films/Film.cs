using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public abstract class Film
    {
        protected Film(string titre, string realisateur, string genre, int anneeSortie, double noteIMDb)
        {
            Titre = titre;
            Realisateur = realisateur;
            Genre = genre;
            NoteIMDb = noteIMDb;
        }

        public string Titre { get; set; }
        public string Realisateur { get; set; }
        public string Genre { get; set; }
        public string AnneeSortie { get; set; }
        public double NoteIMDb { get; set; }

        public abstract void AfficherDetails();

        public string GetTitre() => Titre;
        public string GetRealisateur() => Realisateur;
        public string GetGenre() => Genre;
        public string GetAnneeSortie() => AnneeSortie;
        public double GetNoteIMDb() => NoteIMDb;
    }

}
