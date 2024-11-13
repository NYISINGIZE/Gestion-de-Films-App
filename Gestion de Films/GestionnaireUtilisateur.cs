using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Films
{
    public class GestionnaireUtilisateur
    {
        public void AjouterUtilisateur(List<Utilisateur> utilisateurs, Utilisateur utilisateurActuel, string nom, string email, string motDePasse, string role)
        {
            if (utilisateurActuel.EstAdmin()) // Check if the current user is an admin
            {
                utilisateurs.Add(new Utilisateur(nom, email, motDePasse, role));
                Console.WriteLine("Utilisateur ajouté avec succès!");
            }
            else
            {
                Console.WriteLine("Accès refusé : seul un administrateur peut ajouter un utilisateur.");
            }

        }
    }
}
