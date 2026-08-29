using BookQuoteApi.Data;
using BookQuoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Controllers;

[ApiController]
[Route("api/quotes")]
public class QuoteController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _context = db;

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Quotes controller works!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
    {
        return await _context.Quotes.ToListAsync();
    }


    [HttpGet("get/{userId}")]
    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotesByuserId(string userId)
    {
        var quotes = await _context.Quotes.Where(q => q.UserId.ToString() == userId).ToListAsync();

        if (quotes == null)
        {
            return NotFound();
        }

        return quotes;
    }

}
