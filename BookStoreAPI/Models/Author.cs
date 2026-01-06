using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public record Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; } = null!;
        public string? Bio { get; set; }
        [Required]
        public string Nationality { get; set; } = null!;
        public ICollection<Book>? Books { get; set; } = [];

    }
}
