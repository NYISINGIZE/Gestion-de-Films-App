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
using static System.Net.WebRequestMethods;


namespace Gestion_de_Films
{
    public class Program
    {

        public static void Main(string[] args)
        {



            //AFFICHER LES DETAILS DE FILMS
 
            var collection = new CollectionDeFilms();
            // CollectionDeFilms collectionFilms = new CollectionDeFilms(films);


            collection.ChargerFilmDepuisCSV("title.basics.csv", "title.ratings.csv");

            //Afficher la collection avant la suppression de film
          //collection.AfficherFilms();

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

            GestionnaireUtilisateur gestionUtilisateur = new GestionnaireUtilisateur(utilisateurs);
            /*
            // information des utilisateurs
            Console.WriteLine("Informations des utilisateurs au début:");
            foreach (var utilisateur in utilisateurs)
            {
                utilisateur.AfficherInfosUtilisateur();
            }
            */


            /*

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

            //Authentification de l'administrateur
            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput_ = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput_ = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput_, passwordInput_, out Utilisateur utilisateurActuel))
            {
                Console.WriteLine($"Connexion réussie pour {utilisateurActuel.Nom} ({utilisateurActuel.Role})");

                // Ajout d'un nouvel utilisateur
                gestionUtilisateur.AjouterUtilisateur(utilisateurActuel, "Alice", "alice@uqar.ca", "Alice123", "Client");

                // Afficher la liste des utilisateurs après ajout
                Console.WriteLine("\nListe des utilisateurs après ajout :");
                gestionUtilisateur.AfficherUtilisateurs();
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

            */



            /*
            *****************
       Bloc pour la recherche de films
             ****************









            // Authenticate user
            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput1 = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput1 = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput1, passwordInput1, out Utilisateur utilisateurActuel))
            {
                if (utilisateurActuel.EstClient())
                {
                    Console.WriteLine($"Connexion réussie pour {utilisateurActuel.Nom} (Client)");

                    // Prompt the client to search for a film by title
                    Console.WriteLine("Entrez le titre du film que vous souhaitez rechercher:");
                    string titreRecherche = Console.ReadLine();

                    // Use RechercherParTitre from collection
                    var filmsTrouves = collection.RechercherParTitre(titreRecherche);

                    if (filmsTrouves.Any())
                    {
                        Console.WriteLine("\nFilms trouvés:");
                        foreach (var film in filmsTrouves)
                        {
                            film.AfficherDetails(); // Assuming AfficherDetails exists in FilmDVD
                        }
                    }
                    else
                    {
                        Console.WriteLine("Aucun film trouvé avec ce titre.");
                    }
                }
                else
                {
                    Console.WriteLine("Seuls les clients peuvent rechercher des films.");
                }
            }
            else
            {
                Console.WriteLine("Échec de la connexion. Vérifiez vos identifiants.");
            }

            */


            // NOT WORKING
            /*

            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput3 = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput3 = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput3, passwordInput3, out Utilisateur utilisateurActuel1))
            {
                if (utilisateurActuel1 is Client client)
                {
                    Console.WriteLine($"Connexion réussie pour {client.Nom} (Client)");

                    // Prompt for rental
                    Console.WriteLine("Entrez le titre du film que vous souhaitez louer:");
                    string titreRecherche = Console.ReadLine();

                    // Search for film
                    var filmsTrouves = collection.RechercherParTitre(titreRecherche);

                    if (filmsTrouves.Any())
                    {
                        Console.WriteLine("\nFilms trouvés:");
                        foreach (var film in filmsTrouves)
                        {
                            film.AfficherDetails();
                        }

                        Console.WriteLine("Entrez le titre exact du film à louer:");
                        string titreExactLouer = Console.ReadLine();

                        var filmChoisi = filmsTrouves.FirstOrDefault(f => f.Titre.Equals(titreExactLouer, StringComparison.OrdinalIgnoreCase));

                        if (filmChoisi is FilmDVD filmDVD)
                        {
                            client.LouerFilm(filmDVD);
                        }
                        else
                        {
                            Console.WriteLine("Film non trouvé pour la location.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Aucun film trouvé pour ce titre.");
                    }

                    // Client's rented films - only viewable if functionality exists
                    client.AfficherFilmsEmpruntes();
                }
                else
                {
                    Console.WriteLine("Seulement les clients... ");
                }
            }
            else
            {
                Console.WriteLine("Identification refusé...");
            }


            */



            // USER SEARCHING FILMS




            /*

            

            // User authentication
            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput, passwordInput, out Utilisateur utilisateurActuel))
            {
                if (utilisateurActuel.Role == "Client")
                {
                    // Recreate the Client instance based on utilisateurActuel
                    var client = new Client(utilisateurActuel.Nom, utilisateurActuel.Email, utilisateurActuel.MotDePasse);

                    Console.WriteLine($"Connexion réussie pour {client.Nom} (Client)");

                    // Menu for client
                    Console.WriteLine("\n1. Rechercher un film\n2. Afficher les films empruntés");
                    Console.WriteLine("Choisissez une option:");
                    int choix = int.Parse(Console.ReadLine());

                    switch (choix)
                    {
                        case 1:
                            // Film search
                            Console.WriteLine("Entrez le titre du film que vous souhaitez rechercher:");
                            string titreRecherche = Console.ReadLine();

                            var filmsTrouves = collection.RechercherParTitre(titreRecherche);
                            if (filmsTrouves.Any())
                            {
                                Console.WriteLine("\nFilms trouvés:");
                                foreach (var film in filmsTrouves)
                                {
                                    film.AfficherDetails();
                                }

                                // Rent a film
                                Console.WriteLine("Entrez le titre exact du film à louer:");
                                string titreExactLouer = Console.ReadLine();

                                var filmChoisi = filmsTrouves.FirstOrDefault(f => f.Titre.Equals(titreExactLouer, StringComparison.OrdinalIgnoreCase));
                                if (filmChoisi is FilmDVD filmDVD)
                                {
                                    client.LouerFilm(filmDVD);
                                }
                                else
                                {
                                    Console.WriteLine("Film non trouvé pour la location.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aucun film trouvé avec ce titre.");
                            }
                            break;

                        case 2:
                            // Display rented films
                            client.AfficherFilmsEmpruntes();
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Seuls les clients peuvent accéder à cette section.");
                }
            }
            else
            {
                Console.WriteLine("Échec de la connexion. Vérifiez vos identifiants.");
            }



            */






































            /*


            // User authentication
            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput, passwordInput, out Utilisateur utilisateurActuel))
            {
                if (utilisateurActuel.Role == "Client")
                {
                    var client = new Client(utilisateurActuel.Nom, utilisateurActuel.Email, utilisateurActuel.MotDePasse);

                    Console.WriteLine($"Connexion réussie pour {client.Nom} (Client)");

                    // Menu for client
                    Console.WriteLine("\n1. Rechercher un film\n2. Afficher les films empruntés");
                    Console.WriteLine("Choisissez une option:");
                    int choix = int.Parse(Console.ReadLine());

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Entrez le titre du film que vous souhaitez rechercher:");
                            string titreRecherche = Console.ReadLine();

                            var filmsTrouves = collection.RechercherParTitre(titreRecherche);
                            if (filmsTrouves.Any())
                            {
                                Console.WriteLine("\nFilms trouvés:");
                                foreach (var film in filmsTrouves)
                                {
                                    film.AfficherDetails();
                                }

                                // Rent a film
                                Console.WriteLine("Entrez le titre exact du film à louer:");
                                string titreExactLouer = Console.ReadLine();

                                var filmChoisi = filmsTrouves.FirstOrDefault(f => f.Titre.Equals(titreExactLouer, StringComparison.OrdinalIgnoreCase));
                                if (filmChoisi is FilmDVD filmDVD)
                                {
                                    client.LouerFilm(filmDVD);
                                }
                                else
                                {
                                    Console.WriteLine("Film non trouvé pour la location.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aucun film trouvé avec ce titre.");
                            }
                            break;

                        case 2:
                            client.AfficherFilmsEmpruntes();
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                else if (utilisateurActuel.Role == "Admin")
                {
                    var admin = new Administrateur(utilisateurActuel.Nom, utilisateurActuel.Email, utilisateurActuel.MotDePasse);

                    Console.WriteLine($"Connexion réussie pour {admin.Nom} (Admin)");

                    // Admin menu
                    Console.WriteLine("\nOptions Admin:");
                    Console.WriteLine("1. Voir les films loués par tous les utilisateurs");
                    Console.WriteLine("2. Voir les copies restantes pour tous les films");
                    Console.WriteLine("Choisissez une option:");
                    int choixAdmin = int.Parse(Console.ReadLine());

                    switch (choixAdmin)
                    {
                        case 1:
                            admin.AfficherFilmsEmpruntesParClients(utilisateurs);
                            break;

                        case 2:
                            collection.AfficherDetailsRentedFilms(); // Assumes this method exists in CollectionDeFilms
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Rôle inconnu. Accès refusé.");
                }
            }
            else
            {
                Console.WriteLine("Échec de la connexion. Vérifiez vos identifiants.");
            }


            */

































            // User authentication
            Console.WriteLine("Entrez votre email pour vous connecter:");
            string emailInput = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordInput = Console.ReadLine();

            if (gestionUtilisateur.SeConnecter(emailInput, passwordInput, out Utilisateur utilisateurActuel))
            {
                if (utilisateurActuel.Role == "Client")
                {
                    var client = new Client(utilisateurActuel.Nom, utilisateurActuel.Email, utilisateurActuel.MotDePasse);

                    Console.WriteLine($"Connexion réussie pour {client.Nom} (Client)");

                    // Menu for client
                    Console.WriteLine("\n1. Rechercher un film\n2. Afficher les films empruntés");
                    Console.WriteLine("Choisissez une option:");
                    int choix = int.Parse(Console.ReadLine());

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Choisissez le critère de recherche:");
                            Console.WriteLine("1. Titre\n2. Genre\n3. Réalisateur");
                            int critere = int.Parse(Console.ReadLine());

                            List<FilmDVD> filmsTrouves = new List<FilmDVD>();
                            switch (critere)
                            {
                                case 1:
                                    Console.WriteLine("Entrez le titre du film:");
                                    string titre = Console.ReadLine();
                                    filmsTrouves = collection.RechercherParTitre(titre);
                                    break;

                                case 2:
                                    Console.WriteLine("Entrez le genre du film:");
                                    string genre = Console.ReadLine();
                                    filmsTrouves = collection.RechercherParGenre(genre);
                                    break;

                                case 3:
                                    Console.WriteLine("Entrez le réalisateur du film:");
                                    string realisateur = Console.ReadLine();
                                    filmsTrouves = collection.RechercherParRealisateur(realisateur);
                                    break;

                                default:
                                    Console.WriteLine("Critère invalide.");
                                    break;
                            }

                            if (filmsTrouves.Any())
                            {
                                Console.WriteLine("\nFilms trouvés:");
                                foreach (var film in filmsTrouves)
                                {
                                    film.AfficherDetails();
                                }

                                Console.WriteLine("Entrez le titre exact du film à louer:");
                                string titreExactLouer = Console.ReadLine();

                                var filmChoisi = filmsTrouves.FirstOrDefault(f => f.Titre.Equals(titreExactLouer, StringComparison.OrdinalIgnoreCase));
                                if (filmChoisi is FilmDVD filmDVD)
                                {
                                    client.LouerFilm(filmDVD);
                                }
                                else
                                {
                                    Console.WriteLine("Film non trouvé pour la location.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aucun film trouvé pour ce critère.");
                            }
                            break;

                        case 2:
                            client.AfficherFilmsEmpruntes();
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                else if (utilisateurActuel.Role == "Admin")
                {
                    var admin = new Administrateur(utilisateurActuel.Nom, utilisateurActuel.Email, utilisateurActuel.MotDePasse);

                    Console.WriteLine($"Connexion réussie pour {admin.Nom} (Admin)");

                    // Admin menu
                    Console.WriteLine("\nOptions Admin:");
                    Console.WriteLine("1. Voir les films loués par tous les utilisateurs");
                    Console.WriteLine("2. Voir les copies restantes pour tous les films");
                    Console.WriteLine("Choisissez une option:");
                    int choixAdmin = int.Parse(Console.ReadLine());

                    switch (choixAdmin)
                    {
                        case 1:
                            admin.AfficherFilmsEmpruntesParClients(utilisateurs);
                            break;

                        case 2:
                            collection.AfficherDetailsRentedFilms();
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Rôle inconnu. Accès refusé.");
                }
            }
            else
            {
                Console.WriteLine("Échec de la connexion. Vérifiez vos identifiants.");
            }











































            Console.ReadKey();
            
        }
    }
}


