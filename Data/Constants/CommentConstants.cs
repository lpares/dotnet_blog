using System;
using Blog.Models;

namespace Blog.Data.Constants
{
    public class CommentConstants
    {
        public static List<Comment> Comments = new List<Comment>()
        {
            new Comment()
            {
                Content = "Merci pour cet article très instructif sur C# !",
                IdUser = 2, // Jean Martin
                IdArticle = 1, // Article "Introduction à C#"
                CreatedDate = new DateTime(2025, 1, 2),
                UpdatedDate = new DateTime(2025, 1, 2)
            },
            new Comment()
            {
                Content = "J'ai appris beaucoup de choses grâce à cet article sur .NET.",
                IdUser = 3, // Sophie Leroux
                IdArticle = 2, // Article "Les bases de .NET"
                CreatedDate = new DateTime(2025, 1, 3),
                UpdatedDate = new DateTime(2025, 1, 3)
            },
            new Comment()
            {
                Content = "Je suis d'accord avec les bonnes pratiques mentionnées ici.",
                IdUser = 1, // Alice Dupont
                IdArticle = 3, // Article "Bonnes pratiques en programmation"
                CreatedDate = new DateTime(2025, 1, 4),
                UpdatedDate = new DateTime(2025, 1, 4)
            }
        };
    }
}
