using BookQuoteApi.Data;
using BookQuoteApi.Models;
using BookQuoteApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BookQuoteApi.Controllers;

[Authorize]
[ApiController]
[Route("api/books")]
public class BookController(AppDbContext db):ControllerBase
{
    //private readonly AppDbContext _db = db;

    //[HttpPost]
    //public async Task<ActionResult<Book>> CreateBook(Book book)
    //{
    //    var result = _db.Books.Add(book);
    //    await _db.SaveChangesAsync();

    //    return Ok(result);
    //}

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    //{
    //    return await _db.Books.ToListAsync();
    //}
    private readonly AppDbContext _context = db;

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Books controller works!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Book>> GetBookById(Guid id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost("add")]
    public async Task<ActionResult<Book>> CreateBook(BookRequest request)
    {
        var newBook = new Book
        {
            Title = request.Title,
            Author = request.Author,
            PublicationDate = request.PublicationDate
        };
        _context.Books.Add(newBook);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetBookById),
            new { id = newBook.Id },
            newBook);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        _context.Entry(book).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok(book);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteBook(Guid id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return Ok(book);
    }
}
