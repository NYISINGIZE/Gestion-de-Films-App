using CsvHelper;
using System.Globalization;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System;

namespace Gestion_de_Films
{

   public  class CollectionDeFilms : IGestonDesFilms
    {
        public List<FilmDVD> Films { get; private set; } = new List<FilmDVD>();

        public void AjouterFilm(FilmDVD film)
        {
            Films.Add(film);
        }



        public void SupprimerFilm(FilmDVD film)
        {
            if(Films.Remove(film))
            {
                Console.WriteLine($"Le film '{film.Titre}' a été supprimé avec succès.");
            }
            else
            {
                Console.WriteLine($"Le film '{film.Titre}' n'a pas été trouvé dans la collection.");
            }
            Films.Remove(film);
        }


        // Methode pour modifier le nombre de copie par titre

        public void ModifierNbCopiesFilmParTitre(string titre, int newNbCopies)
        {
            var film = Films.Find(f => f.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
            if (film != null)
            {
                film.ModifierNbCopies(newNbCopies);
                Console.WriteLine($"Le nombre de copies pour '{titre}' a été mis à jour à {newNbCopies}.");
            }
            else
            {
                Console.WriteLine($"Film '{titre}' non trouvé dans la collection.");
            }
        }

        //Supprimer Film par Titre

        public void SupprimerFilmParTitre(string titre)
        {
            var filmASupprimer = Films.Find(film => film.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));

            if (filmASupprimer != null)
            {
                SupprimerFilm(filmASupprimer);
            }
            else
            {
                Console.WriteLine($"Le film '{titre}' n'a pas été trouvé dans la collection.");
            }
        }


        public void AfficherFilms()
        {
            foreach (var film in Films)
            {
                film.AfficherDetails();
            }
        }


        // Implementation d'une methode pour charger les films a partir de CSV file

        /*
        public void ChargerFilmDepuisCSV(string titleBasicPath, string titleRatingPath)
        {
            // une dictionnaire pour stocker les donnes IDMb par film
            var ratingsDict = new Dictionary<string, double>();

            //Charger les donnees ratings

            using (var reader = new StreamReader(titleBasicPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var id = csv.GetField("tconst");
                    var title = csv.GetField("primaryTitle");
                    var director = csv.GetField("primaryTitle");
                    var genre = csv.GetField("genres");
                    var yearString = csv.GetField("startYear")?.Trim();
                    //var yearString = csv.GetField("startYear");
                    int.TryParse(yearString, out int parsedYear);

                    //Verifier si une note est disponible
                    ratingsDict.TryGetValue(id, out double rating);

                    //Creation d'une instance FilmDVD
                    
                    /*var film = new FilmDVD()
                    {

                        Titre = title,
                        Realisateur = director,
                        Genre = genre,
                        AnneeSortie = year,
                        NoteIMDb = rating,
                        NbCopiesDisponibles = 10, //nombre par defaut 
                        PrixLocation = 3.55m // prix pour la location
                       

                    };
                    */
        /*

                   var film = new FilmDVD(
                        title,          // Titre
                        director,       // Realisateur
                        genre,          // Genre
                        //int.TryParse(year, out int parsedYear) ? parsedYear : 0, // AnneeSortie with error handling
                                                             //int.Parse(year), // AnneeSortie
                        parsedYear,
                        rating,         // NoteIMDb
                        10,             // NbCopiesDisponibles (default value)
                        3.55m          // PrixLocation (default rental price)
                    );

                    AjouterFilm(film);

        */

        public void ChargerFilmDepuisCSV(string titleBasicPath, string titleRatingPath)
        {
            // Dictionary to store ratings by film ID
            var ratingsDict = new Dictionary<string, double>();

            // First, load the ratings data into ratingsDict
            using (var reader = new StreamReader(titleRatingPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var id = csv.GetField("tconst");
                    var averageRatingString = csv.GetField("averageRating");

                    if (double.TryParse(averageRatingString, out double averageRating))
                    {
                        ratingsDict[id] = averageRating;
                    }
                }
            }

            // Now, load film data and retrieve the rating from ratingsDict
            using (var reader = new StreamReader(titleBasicPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var id = csv.GetField("tconst");
                    var title = csv.GetField("primaryTitle");
                    var director = csv.GetField("primaryTitle");
                    var genre = csv.GetField("genres");
                    var yearString = csv.GetField("startYear")?.Trim();
                    int parsedYear = int.TryParse(yearString, out int year) ? year : 0;

                    // Try to get the rating from the dictionary
                    ratingsDict.TryGetValue(id, out double rating);

                    // Create FilmDVD instance
                    var film = new FilmDVD(
                        title,                    // Titre
                        director,                 // Realisateur
                        genre,                    // Genre
                        parsedYear,               // AnneeSortie
                        rating,                   // NoteIMDb
                        10,                       // NbCopiesDisponibles
                        3.55m                     // PrixLocation
                    );

                    AjouterFilm(film);



                }


            }
        }
    }

}
