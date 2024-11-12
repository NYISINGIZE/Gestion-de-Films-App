using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class FilmDVD : Film
    {
        public int NbCopiesDisponibles { get; set; }
        public decimal PrixLocation { get; set; }


        //Afficher les Details des films
        public override void AfficherDetails()
        {
            Console.WriteLine($"Title: {Titre}");
            Console.WriteLine($"Director: {Realisateur}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Release Year: {AnneeSortie}");
            Console.WriteLine($"IMDb Rating: {NoteIMDb}");
            Console.WriteLine($"Copies Available: {NbCopiesDisponibles}");
            Console.WriteLine($"Rental Price: {PrixLocation:C}");
            Console.WriteLine("------------------");
        }


        //Modifier le nombre de copies disponible

     public FilmDVD(string titre, string realisateur, string genre, int anneeSortie, double noteIMDb, int nbCopiesDisponibles, decimal prixLocation)
    : base(titre, realisateur, genre, anneeSortie, noteIMDb)
        {
            NbCopiesDisponibles = nbCopiesDisponibles;
            PrixLocation = prixLocation;
        }

        public void ModifierNbCopies(int newNbCopies)
        {
            if (newNbCopies >= 0)
            {
                NbCopiesDisponibles = newNbCopies;
                Console.WriteLine($"Nombre de copies pour '{Titre}' mis à jour à {NbCopiesDisponibles}.");
            }
            else
            {
                Console.WriteLine("Le nombre de copies ne peut pas être négatif.");
            }
        }




        /*
        public void ModifierNbCopies(int newCount)
        {
            NbCopiesDisponibles = newCount;
        }
        */


    }
}
