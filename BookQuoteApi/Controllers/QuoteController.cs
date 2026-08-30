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

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Quote>>> GetAllQuotes()
    //{
    //    return await _context.Quotes.ToListAsync();
    //}

    [HttpGet("get/{id}")]
    public async Task<ActionResult<QuoteResponse>> GetQuoteById(Guid id)
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

        return new QuoteResponse
        {
            Id = quote.Id,
            QuoteText = quote.QuoteText
        };
    }

    [HttpGet("get-my-quotes")]
    public async Task<ActionResult<IEnumerable<QuoteResponse>>> GetMyQuotes()
    {
        var userId = GetCurrentUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var quotes = await _context.Quotes.Where(q => q.UserId == userId).ToListAsync();

        var quoteResponses = quotes.Select(q => new QuoteResponse
        {
            Id = q.Id,
            QuoteText = q.QuoteText,
            CreatedAt = q.CreatedAt,
            UpdatedAt = q.UpdatedAt
        }).OrderByDescending(q => q.UpdatedAt).ToList();
        return quoteResponses;
    }


    [HttpPost("add")]
    public async Task<ActionResult<Quote>> CreateQuote(QuoteRequest request)
    {
        var userId = GetCurrentUserId();
        var newQuote = new Quote
        {
            QuoteText = request.QuoteText,
            UserId = userId.Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Quotes.Add(newQuote);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetQuoteById),
            new { id = newQuote.Id },
            newQuote);
    }


    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateQuote(Guid id, QuoteRequest request)
    {
        var userId = GetCurrentUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        var quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id && q.UserId == userId);

        if (quote == null)
        {
            return NotFound();
        }
        quote.QuoteText = request.QuoteText;
        quote.UpdatedAt = DateTime.UtcNow;

        _context.Entry(quote).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok(request);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteQuote(Guid id)
    {
        var userId = GetCurrentUserId();
        if (userId == null)
        {
            return Unauthorized();
        }
        var quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id && q.UserId == userId);

        if (quote == null)
        {
            return NotFound();
        }

        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();

        return Ok(quote);
    }


}
