using System;
using Blog.Models;

namespace Blog.Data.Constants
{
    public class ArticleConstants
    {
        public static List<Article> Articles = new List<Article>()
        {
            new Article()
            {
                Title = "Introduction à C#",
                Content = "C# est un langage de programmation moderne et orienté objet développé par Microsoft.",
                CreatedDate = new DateTime(2025, 1, 1),
                UpdatedDate = new DateTime(2025, 1, 1)
            },
            new Article()
            {
                Title = "Les bases de .NET",
                Content = ".NET est un framework qui permet de développer des applications pour Windows, le web et bien plus encore.",
                CreatedDate = new DateTime(2025, 1, 2),
                UpdatedDate = new DateTime(2025, 1, 2)
            },
            new Article()
            {
                Title = "Bonnes pratiques en programmation",
                Content = "Voici quelques bonnes pratiques pour écrire du code propre et maintenable.",
                CreatedDate = new DateTime(2025, 1, 3),
                UpdatedDate = new DateTime(2025, 1, 3)
            }
        };
    }
}
