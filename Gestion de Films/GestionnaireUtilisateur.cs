using System;
using System.Collections.Generic;


namespace Gestion_de_Films
{
    public class GestionnaireUtilisateur
    {
        private List<Utilisateur> utilisateurs;
        public GestionnaireUtilisateur(List<Utilisateur> utilisateurs)
        {
            this.utilisateurs = utilisateurs;
        }

        //Methode pour la connexion
        public bool SeConnecter(string email, string motDePasse, out Utilisateur utilisateurActuel)
        {
            utilisateurActuel = utilisateurs.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return utilisateurActuel != null && utilisateurActuel.SeConnecter(email, motDePasse);
        }

        //Methode pour ajouter les utilisateurs
        public void AjouterUtilisateur(Utilisateur utilisateurActuel, string nom, string email, string motDePasse, string role)
        {
            if (utilisateurActuel.EstAdmin())
            {
                utilisateurs.Add(new Utilisateur(nom, email, motDePasse, role));
                Console.WriteLine("Utilisateur ajouté avec succès!");
            }
            else
            {
                Console.WriteLine("Accès refusé : seul un administrateur peut ajouter un utilisateur.");
            }
        }

        // Afficher les Utilisateurs
        public void AfficherUtilisateurs()
        {
            Console.WriteLine("\nListe des utilisateurs :");
            foreach (var utilisateur in utilisateurs)
            {
                utilisateur.AfficherInfosUtilisateur();
            }
        }
    }
}

