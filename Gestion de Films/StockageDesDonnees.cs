using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class StockageDesDonnees
    {
        public void SaveUsersToJson(List<Utilisateur> utilisateurs)
        {
            try
            {
                // Serialize the list of users to JSON format
                string json = JsonConvert.SerializeObject(utilisateurs, Formatting.Indented);

                // Write the JSON string to a file
                File.WriteAllText("users.json", json);

                Console.WriteLine("Users have been successfully saved to 'users.json'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving users to JSON: {ex.Message}");
            }
        }
        //    // Method to display users

        public void DisplayUsers(List<Utilisateur> utilisateurs)
        {
            if (utilisateurs.Count == 0)
            {
                Console.WriteLine("No users available.");
            }
            else
            {
                foreach (var utilisateur in utilisateurs)
                {
                    utilisateur.AfficherInfosUtilisateur();
                }
            }
        }

        // Method to save films to a JSON file
        public void SaveFilmsToJson(List<FilmDVD> films)
        {
            try
            {
                // Serialize the list of films to JSON format
                string json = JsonConvert.SerializeObject(films, Formatting.Indented);

                // Write the JSON string to a file
                File.WriteAllText("films.json", json);

                Console.WriteLine("Films have been successfully saved to 'films.json'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving films to JSON: {ex.Message}");
            }
        }

        // Method to load films from a JSON file
        public List<FilmDVD> LoadFilmsFromJson()
        {
            try
            {
                if (File.Exists("films.json"))
                {
                    string json = File.ReadAllText("films.json");
                    List<FilmDVD> films = JsonConvert.DeserializeObject<List<FilmDVD>>(json);
                    return films;
                }
                else
                {
                    Console.WriteLine("The films file does not exist.");
                    return new List<FilmDVD>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading films from JSON: {ex.Message}");
                return new List<FilmDVD>();
            }
        }

    }
}


