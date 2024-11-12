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


            Console.ReadKey();
            
        }
    }
}


