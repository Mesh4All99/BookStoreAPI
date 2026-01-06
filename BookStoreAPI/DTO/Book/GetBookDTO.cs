using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTO.Book
{
    public record GetBookDTO
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string ISBN { get; set; } = null!;
        public decimal Price { get; set; }
        public string AuthorName { get; set; } = null!;
        public int? PageCount { get; set; }
        public string CoverUrl { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
