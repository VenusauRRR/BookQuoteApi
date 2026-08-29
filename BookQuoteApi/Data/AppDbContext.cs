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
    public DbSet<Quote> Quotes => Set<Quote>();

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
                PasswordHash = "$2a$11$kdkkb02uH1l3mEwE9XJade17qR9qnrAwAJgTqN5gm.HbunF.954P2"
            },
            new User
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Username = "Mary_smith",
                Email = "mary_smith@example.com",
                PasswordHash = "$2a$11$dnE9bXLxEyQA7wrLWc7mveCpwtb3NGQC.xmnIYPDC1bL3kq4b90X6"
            }
        );

        modelBuilder.Entity<Quote>().HasData(
    // John Doe - 5 quotes
    new Quote
    {
        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
        QuoteText = "It is never too late to become what you might have been.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
    },
    new Quote
    {
        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
        QuoteText = "The only way out is through.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
    },
    new Quote
    {
        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
        QuoteText = "Not all those who wander are lost.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
    },
    new Quote
    {
        Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
        QuoteText = "The future depends on what you do today.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
    },
    new Quote
    {
        Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
        QuoteText = "Success is the sum of small efforts, repeated day in and day out.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
    },

    // Mary Smith - 5 quotes
    new Quote
    {
        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
        QuoteText = "Whatever you are, be a good one.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
    },
    new Quote
    {
        Id = Guid.Parse("12121212-1212-1212-1212-121212121212"),
        QuoteText = "There is no charm equal to tenderness of heart.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
    },
    new Quote
    {
        Id = Guid.Parse("34343434-3434-3434-3434-343434343434"),
        QuoteText = "Every moment is a fresh beginning.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
    },
    new Quote
    {
        Id = Guid.Parse("56565656-5656-5656-5656-565656565656"),
        QuoteText = "What we think, we become.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
    },
    new Quote
    {
        Id = Guid.Parse("78787878-7878-7878-7878-787878787878"),
        QuoteText = "Happiness depends upon ourselves.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
    }
);
    }
}
