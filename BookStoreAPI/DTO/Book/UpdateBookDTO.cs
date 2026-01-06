namespace BookStoreAPI.DTO.Book
{
    public class UpdateBookDTO
    {
        public string ISBN { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string? Description { get; set; }
        public string CoverUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public int? PageCount { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
