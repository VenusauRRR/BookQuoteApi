using BookQuoteApi.Data;
using BookQuoteApi.DTOs;
using BookQuoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookQuoteApi.Controllers;

[Authorize]
[ApiController]
[Route("api/quotes")]
public class QuoteController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _context = db;

    private Guid? GetCurrentUserId()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString == null)
        {
            return null;
        }
        return Guid.Parse(userIdString);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Quotes controller works!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quote>>> GetAllQuotes()
    {
        return await _context.Quotes.ToListAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Quote>> GetQuoteById(Guid id)
    {
        var userId = GetCurrentUserId();

        if (userId == null)
        {
            return Unauthorized();
        }
        var quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id==id && q.UserId == userId);

        if (quote == null)
        {
            return NotFound();
        }

        return quote;
    }

    [HttpGet("get-my-quotes")]
    public async Task<ActionResult<IEnumerable<Quote>>> GetMyQuotes()
    {
        var userId = GetCurrentUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var quotes = await _context.Quotes.Where(q => q.UserId == userId).ToListAsync();

        return quotes;
    }


    [HttpPost("add")]
    public async Task<ActionResult<Quote>> CreateQuote(QuoteRequest request)
    {
        var userId = GetCurrentUserId();
        var newQuote = new Quote
        {
            QuoteText = request.QuoteText,
            UserId = userId.Value,
        };


        _context.Quotes.Add(newQuote);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetQuoteById),
            new { id = newQuote.Id },
            newQuote);
    }

}
