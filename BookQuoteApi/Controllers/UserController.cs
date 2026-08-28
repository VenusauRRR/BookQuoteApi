using BookQuoteApi.Data;
using BookQuoteApi.Models;
using BookQuoteApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookQuoteApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(AppDbContext db, IConfiguration configuration) : ControllerBase
{
    private readonly AppDbContext _context = db;
    private readonly IConfiguration _configuration = configuration;

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

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1),
            signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new LoginResponse
        {
            Token = tokenString
        });

    }
}