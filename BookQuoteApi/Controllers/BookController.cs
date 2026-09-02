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
    private readonly AppDbContext _context = db;

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Books controller works!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.OrderByDescending(q => q.UpdatedAt).ToListAsync();
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
            PublicationDate = request.PublicationDate,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
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

        var existingBook = await _context.Books.FindAsync(id);

        if (existingBook == null)
        {
            return NotFound();
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.PublicationDate = book.PublicationDate;
        existingBook.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(existingBook);
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
