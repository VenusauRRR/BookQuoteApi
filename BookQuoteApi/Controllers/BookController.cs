using BookQuoteApi.Data;
using BookQuoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Controllers;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetBook),
            new { id = book.Id },
            book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        _context.Entry(book).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
