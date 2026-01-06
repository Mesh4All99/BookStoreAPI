using BookStoreAPI.Interfaces;
using BookStoreAPI.Interfaces.Implementation;
using BookStoreAPI.Mappers.Books;
using BookStoreAPI.Models;
using BookStoreAPI.DTO.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        public BookController(IRepository<Book> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var RawData = await _repository.GetAllAsync(query =>
                query.Include(b => b.Author)
                     .Include(b => b.Category)
            );

            var data = RawData.Select(s => s.ToGetBookDTO());
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var data = await _repository.GetAsync(
                predicate: x => x.BookId == id,
                include: query => query.Include(b => b.Author).Include(b => b.Category)
            );

            if (data is null)
            {
                return NotFound("Book with the given id not found.");
            }

            var book = data.ToGetBookDTO();
            return Ok(book);
        }
        [HttpPost()]
        public async Task<ActionResult<Book>> AddBook([FromBody] PostBookDTO book)
        {
            var newBook = book.toPostBookDTO();
            if (newBook is null)
            {
                return Problem("Please provide a correct book informations.");
            }
            await _repository.AddAsync(newBook);
            return CreatedAtAction(nameof(GetById), new {id = newBook.BookId}, newBook);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> Update(UpdateBookDTO book, int id)
        {
            var bookItem = await _repository.GetByIdAsync(id);
            if(bookItem is null)
            {
                return NotFound();
            }
            bookItem.ISBN = book.ISBN;
            bookItem.PublishDate = book.PublishDate;
            bookItem.Description = book.Description;
            bookItem.CoverUrl = book.CoverUrl;
            bookItem.Title = book.Title;
            bookItem.Price = book.Price;
            bookItem.PageCount = book.PageCount;
            bookItem.InStock = book.InStock;
            bookItem.AuthorId = book.AuthorId;
            bookItem.CategoryId = book.CategoryId;
            
            await _repository.UpdateAsync(bookItem);
            return Ok(book);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
