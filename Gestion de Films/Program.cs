using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace Gestion_de_Films
{
    public class Program
    {

        public static void Main(string[] args)
        {


            //AFFICHER LES DETAILS DE FILMS
            var collection = new CollectionDeFilms();
            collection.ChargerFilmDepuisCSV("title.basics.csv", "title.ratings.csv");

            //Afficher la collection avant la suppression de film
          //  collection.AfficherFilms();

            //SUPPRESSION DE FILM "Carmencita"
                        collection.SupprimerFilmParTitre("Carmencita");

            Console.WriteLine(" - - - - - - - - - - - - - - -");

            Console.WriteLine("COLLECTION AFTER DELETION");
            Console.WriteLine(" - - - - - - - - - - - - - - -");


            // CHANGER NOMBRE DE COPIES PAR TITRE DU FILM
            collection.ModifierNbCopiesFilmParTitre("Le clown et ses chiens", 9); // Update to desired film title and copy number

           //collection.AfficherFilms();

            /*************
             
 ====== GESTION D'UTILISATEURS ========
            *************/

            // Creation de deux utilisateur; CLIENT et ADMIN

            List<Utilisateur> utilisateurs = new List<Utilisateur>
            {
                new Utilisateur("Theo", "theo@uqar.ca", "Theo123", "Admin"),
                new Utilisateur("Remy", "remy@uqar.ca", "Remy123", "Admin"),
                new Utilisateur("Bob", "bob@uqar.ca", "Bob123", "Client"),
            };

            // information des utilisateurs
            Console.WriteLine("Informations des utilisateurs au début:");
            foreach (var utilisateur in utilisateurs)
            {
                utilisateur.AfficherInfosUtilisateur();
            }

            // VERIFICATION DE CONNEXION
            Console.WriteLine("Entrez votre email:");
            string emailInput = Console.ReadLine();

           Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput = Console.ReadLine();

            // Verification de l'identite
            Utilisateur utilisateurTest = utilisateurs.Find(u => u.Email.Equals(emailInput, StringComparison.OrdinalIgnoreCase));

            if (utilisateurTest != null)
            {
                bool loginSuccess = utilisateurTest.SeConnecter(emailInput, passwordInput);
                Console.WriteLine($"Connexion pour {utilisateurTest.Nom} ({utilisateurTest.Role}): {(loginSuccess ? "Réussi" : "Échoué")}");
            }
            else
            {
                Console.WriteLine("Utilisateur non trouvé.");
            }


            //AJOUTER UN UTILISATEUR - SEUL ADMIN PEUT FAIRE
            GestionnaireUtilisateur gestionUtilisateur = new GestionnaireUtilisateur();
            //Authentification de l'administrateur

            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput_ = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput_ = Console.ReadLine();

            // Rechercher l'utilisateur par e-mail
            Utilisateur utilisateurActuel = utilisateurs.Find(u => u.Email.Equals(emailInput_, StringComparison.OrdinalIgnoreCase));

            if (utilisateurActuel != null && utilisateurActuel.SeConnecter(emailInput_, passwordInput_)) // Vérification de l'authentification
            {
                Console.WriteLine($"Connexion réussie pour {utilisateurActuel.Nom} ({utilisateurActuel.Role})");

                //L'utilisateur est connecté, vérifier s'il est administrateur
                gestionUtilisateur.AjouterUtilisateur(utilisateurs, utilisateurActuel, "Alice", "alice@uqar.ca", "Alice123", "Client");

                // Affichage des utilisateurs après l'ajout
                Console.WriteLine("\nListe des utilisateurs après ajout :");
                foreach (var utilisateur in utilisateurs)
                {
                    utilisateur.AfficherInfosUtilisateur();
                }
            }
            else
            {
                Console.WriteLine("Échec de la connexion. Utilisateur non trouvé ou mot de passe incorrect.");
            }









            // MISE À JOUR DES DÉTAILS D'UN UTILISATEUR
            string emailToUpdate = "theo@uqar.ca"; // Courriel de l'utilisateur à mettre à jour
            Utilisateur utilisateurToUpdate = utilisateurs.Find(u => u.Email.Equals(emailToUpdate, StringComparison.OrdinalIgnoreCase));

            if (utilisateurToUpdate != null)
            {
                Console.WriteLine($"\nMise à jour des informations de l'utilisateur avec l'email: {emailToUpdate}");
                utilisateurToUpdate.MettreAJourDetails("TheoUpdated", "newtheo@uqar.ca", "NewTheo123");
            }
            else
            {
                Console.WriteLine($"\nUtilisateur avec l'email {emailToUpdate} non trouvé.");
            }

            // Afficher la liste des utilisateurs après la mise à jour
            Console.WriteLine("\nListe des utilisateurs après mise à jour :");
            foreach (var utilisateur in utilisateurs)
            {
                utilisateur.AfficherInfosUtilisateur();
            }

            Console.ReadKey();
            
        }
    }
}


