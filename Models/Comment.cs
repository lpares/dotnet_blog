using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int IdUser { get; set; }

        [Required]
        [ForeignKey("Article")]
        public int IdArticle { get; set; }

        [ForeignKey("Comment")]
        public int IdComment { get; set; }
    }
}
