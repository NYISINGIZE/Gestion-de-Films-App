using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class Utilisateur
    {
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; private set; } // Role peut etre "Admin" ou "Client"

        // Constructeur avec attribution de rôle
        public Utilisateur(string nom, string email, string motDePasse, string role)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Role = role;
        }

        // Method for displaying user information
        public void AfficherInfosUtilisateur()
        {
            Console.WriteLine($"Nom: {Nom}, Email: {Email}, Role: {Role}");
        }

        // Authentication method
        public bool SeConnecter(string email, string motDePasse)
        {
            if (Email.Equals(email, StringComparison.OrdinalIgnoreCase) && MotDePasse == motDePasse)
            {
                Console.WriteLine($"Connexion réussie pour l'utilisateur: {Nom} ({Role})");
                return true;
            }
            Console.WriteLine("Échec de la connexion. Identifiants incorrects.");
            return false;
        }

        // Update user details method
        public void MettreAJourDetails(string nom, string email, string motDePasse)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Console.WriteLine("Les informations de l'utilisateur ont été mises à jour.");
        }
    }



}
