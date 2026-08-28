using BookQuoteApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                PublicationDate = new DateTime(1937, 9, 21)
            },
            new Book
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "1984",
                Author = "George Orwell",
                PublicationDate = new DateTime(1949, 6, 8)
            },
            new Book
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                PublicationDate = new DateTime(1813, 1, 28)
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Username = "john_doe",
                Email = "john.doe@example.com",
                PasswordHash = "jD111"
            },
            new User
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Username = "Mary_smith",
                Email = "mary_smith@example.com",
                PasswordHash = "mS222"
            }
        );
    }
}
