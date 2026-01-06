using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public record Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public ICollection<Book>? Books { get; set; } = [];
    }
}
