using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int Role { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }
    }
}