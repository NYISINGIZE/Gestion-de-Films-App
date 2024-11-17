using System;
using System.Collections.Generic;


namespace Gestion_de_Films
{
    public class Utilisateur
    {
        public string Nom { get; private set; }
        public string Email { get; private set; }
        public string MotDePasse { get; set; } // Ajoutez "private"
        public string Role { get; private set; }

        //Definition d'une propriété pour louer les films
        public List<Film> FilmsLoues { get; private set; } = new List<Film>();

        public Utilisateur(string nom, string email, string motDePasse, string role)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Role = role;
        }

        //Afficher les informations des utilisateurs
        public void AfficherInfosUtilisateur()
        {
            Console.WriteLine($"Nom: {Nom}, Email: {Email}, Role: {Role}");
        }

        //Methode pour se connecter
        public bool SeConnecter(string email, string motDePasse)
        {
            return Email.Equals(email, StringComparison.OrdinalIgnoreCase) && MotDePasse == motDePasse;
        }

        public bool EstAdmin()
        {
            return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        //Methode pour la mise ajour des details des utilisateurs



        public void MettreAJourDetails(string nom, string email, string motDePasse)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Console.WriteLine("Les informations de l'utilisateur ont été mises à jour.");
        }


        public bool EstClient()
        {
            return Role.Equals("Client", StringComparison.OrdinalIgnoreCase);
        }

            // Méthode pour ajouter un film loué
        public void LouerFilm(Film film)
        {
            FilmsLoues.Add(film);
            Console.WriteLine($"Film '{film.Titre}' loué par {Nom}.");
        }
    }
}
