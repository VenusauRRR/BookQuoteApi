using BookQuoteApi.Data;
using BookQuoteApi.Models;
using BookQuoteApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _context = db;

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Users controller works!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }


    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser(UserRequest request)
    {
        var newUser = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = newUser.Id },
            newUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest request)
    {
        string login_err_msg = "Invalid username or password";

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null)
        {
            return Unauthorized(login_err_msg);
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!passwordValid)
        {
            return Unauthorized(login_err_msg);
        }

        return Ok("Login successful!");
    }
}