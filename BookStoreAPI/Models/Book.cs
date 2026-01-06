using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public record Book
    {
        [Key]
        public int BookId { get; set; } 
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public string ISBN { get; set; } = null!;
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int? PageCount { get; set; }
        [Required]
        public string CoverUrl { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public Category Category { get; set; } = null!;

    }
}
