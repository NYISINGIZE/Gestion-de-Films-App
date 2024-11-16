using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;


namespace Gestion_de_Films
{

   public  class CollectionDeFilms : IGestonDesFilms
    {
        public List<FilmDVD> Films { get; private set; } = new List<FilmDVD>();
        public CollectionDeFilms() { }
        public CollectionDeFilms(List<FilmDVD> films)
        {
            Films = films;
        }

        public void AjouterFilm(FilmDVD film)
        {
            Films.Add(film);
        }


        //SupprimerFilm

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


        //RechercherParTitre
        public List<FilmDVD> RechercherParTitre(string titre)
        {
            return Films.Where(f => f.Titre.IndexOf(titre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        //RechercherParGenre
        public List<FilmDVD> RechercherParGenre(string genre)
        {
            return Films.Where(f => f.Genre.IndexOf(genre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // RechercherParRealisateur
        public List<FilmDVD> RechercherParRealisateur(string realisateur)
        {
            return Films.Where(f => f.Realisateur.IndexOf(realisateur, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
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

        // METHODE POUR AfficherDetailsRentedFilms
        public void AfficherDetailsRentedFilms()
        {
            Console.WriteLine("\nDétails des films loués et copies restantes:");

            foreach (var film in Films)
            {
                int initialCopies = 10; // Assume initial number of copies is 10
                int rentedCopies = initialCopies - film.NbCopiesDisponibles;

                // Show only films that have been rented at least once
                if (rentedCopies > 0)
                {
                    Console.WriteLine($"Titre: {film.Titre}, Copies restantes: {film.NbCopiesDisponibles}, Copies louées: {rentedCopies}");
                }
            }
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

        // Methode pour Afficher Films
        public void AfficherFilms()
        {
            foreach (var film in Films)
            {
                film.AfficherDetails();
            }
        }

        // Method to search films by title

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
