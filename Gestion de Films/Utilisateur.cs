using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class Utilisateur
    {

        public string Nom { get; private set; }
        public string Email { get; private set; }
        private string MotDePasse { get; set; }
        public string Role { get; private set; }

        // Constructeur avec attribution de rôle
        public Utilisateur(string nom, string email, string motDePasse, string role)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Role = role;
        }

        // Méthode pour afficher les informations de l'utilisateur
        public void AfficherInfosUtilisateur()
        {
            Console.WriteLine($"Nom: {Nom}, Email: {Email}, Role: {Role}");
        }

        // Méthode pour l'authentification
        public bool SeConnecter(string email, string motDePasse)
        {
            return Email.Equals(email, StringComparison.OrdinalIgnoreCase) && MotDePasse == motDePasse;
        }

        // Vérification si l'utilisateur est un administrateur
        public bool EstAdmin()
        {
            return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        // Vérification si l'utilisateur est un client
        public bool EstClient()
        {
            return Role.Equals("Client", StringComparison.OrdinalIgnoreCase);
        }

        // Méthode pour mettre à jour les détails de l'utilisateur
        public void MettreAJourDetails(string nom, string email, string motDePasse)
        {
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            Console.WriteLine("Les informations de l'utilisateur ont été mises à jour.");
        }

        //Ajouter un nouveau utilisateur
        public void AjouterUtilisateur(List<Utilisateur> utilisateurs, Utilisateur utilisateurActuel, string nom, string email, string motDePasse, string role)
        {
            if (utilisateurActuel.EstAdmin()) // Vérifier si l'utilisateur est un admin
            {
                utilisateurs.Add(new Utilisateur(nom, email, motDePasse, role));
                Console.WriteLine("Utilisateur ajouté avec succès!");
            }
            else
            {
                Console.WriteLine("Accès refusé : seul un administrateur peut ajouter un utilisateur.");
            }
        }




        /*
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
            if (Role == "Admin")
            {
                Nom = nom;
                Email = email;
                MotDePasse = motDePasse;
                Console.WriteLine("Les informations de l'utilisateur ont été mises à jour.");
            }
            else
            {
                Console.WriteLine("Mise à jour refusée. Seul un administrateur peut mettre à jour les informations.");
            }
        }*/




    }



}
