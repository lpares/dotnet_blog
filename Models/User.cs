using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Models
{
    //public class User : IdentityUser
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdentityId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        private string _password;

        [Required]
        public string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }

        [Required]
        public int Role { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}