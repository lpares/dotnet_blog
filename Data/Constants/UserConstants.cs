using System;
using Blog.Models;

namespace Blog.Data.Constants
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Name = "Alice Dupont",
                Email = "alice.dupont@example.com",
                Password = "MotDePasse123!", // Le mot de passe sera haché automatiquement grâce à la propriété Password
                Role = 1, // Exemple : 1 pour un rôle administrateur
                CreatedDate = new DateTime(2025, 1, 1),
                UpdatedDate = new DateTime(2025, 1, 1)
            },
            new User()
            {
                Name = "Jean Martin",
                Email = "jean.martin@example.com",
                Password = "AutreMotDePasse123!", // Haché automatiquement
                Role = 0, // Exemple : 0 pour un rôle utilisateur standard
                CreatedDate = new DateTime(2025, 1, 2),
                UpdatedDate = new DateTime(2025, 1, 2)
            },
            new User()
            {
                Name = "Sophie Leroux",
                Email = "sophie.leroux@example.com",
                Password = "MotDePasseSecurise123!", // Haché automatiquement
                Role = 0,
                CreatedDate = new DateTime(2025, 1, 3),
                UpdatedDate = new DateTime(2025, 1, 3)
            }
        };
    }
}
