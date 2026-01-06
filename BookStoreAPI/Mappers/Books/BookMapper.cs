using BookStoreAPI.DTO.Book;
using BookStoreAPI.Models;
namespace BookStoreAPI.Mappers.Books
{
    public static class BookMapper
    {
        public static GetBookDTO ToGetBookDTO(this Book book)
        {
            return new GetBookDTO()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                AuthorName = book.Author.AuthorName,
                Price = book.Price,
                PublishDate = book.PublishDate,
                InStock = book.InStock,
                PageCount = book.PageCount,
                CoverUrl = book.CoverUrl,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
            };
        }
        public static Book toPostBookDTO(this PostBookDTO book)
        {
            return new Book()
            {
                BookId = new(),
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                Price = book.Price,
                PublishDate = book.PublishDate,
                InStock = book.InStock,
                PageCount = book.PageCount,
                CoverUrl = book.CoverUrl,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                Author = null!,
                Category = null!,
            };
        }
        public static Book toUpdateBookDTO(this UpdateBookDTO book)
        {
            return new Book()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                Price = book.Price,
                PublishDate = book.PublishDate,
                InStock = book.InStock,
                PageCount = book.PageCount,
                CoverUrl = book.CoverUrl,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
            };
        }
    }
}
