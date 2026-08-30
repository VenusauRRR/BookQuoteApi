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
        PublicationDate = new DateTime(1937, 9, 21),
        CreatedAt = new DateTime(2001, 12, 30, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2001, 12, 30, 10, 0, 0, DateTimeKind.Utc)
    },
    new Book
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Title = "1984",
        Author = "George Orwell",
        PublicationDate = new DateTime(1949, 6, 8),
        CreatedAt = new DateTime(1998, 1, 12, 23, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(1998, 1, 12, 23, 0, 0, DateTimeKind.Utc)
    },
    new Book
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Title = "Pride and Prejudice",
        Author = "Jane Austen",
        PublicationDate = new DateTime(1813, 1, 28),
        CreatedAt = new DateTime(2010, 9, 15, 4, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2010, 9, 15, 4, 0, 0, DateTimeKind.Utc)
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
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        CreatedAt = new DateTime(1923, 2, 14, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(1923, 2, 14, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
        QuoteText = "The only way out is through.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        CreatedAt = new DateTime(2012, 5, 17, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt=new DateTime(2012, 5, 17, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
        QuoteText = "Not all those who wander are lost.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        CreatedAt = new DateTime(1956, 10, 27, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt=new DateTime(1956, 10, 27, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
        QuoteText = "The future depends on what you do today.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        CreatedAt = new DateTime(1823, 8, 12, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(1823, 8, 12, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
        QuoteText = "Success is the sum of small efforts, repeated day in and day out.",
        UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        CreatedAt = new DateTime(2017, 2, 28, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2017, 2, 28, 10, 0, 0, DateTimeKind.Utc)
    },

    // Mary Smith - 5 quotes
    new Quote
    {
        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
        QuoteText = "Whatever you are, be a good one.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        CreatedAt = new DateTime(1954, 11, 26, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(1954, 11, 26, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("12121212-1212-1212-1212-121212121212"),
        QuoteText = "There is no charm equal to tenderness of heart.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        CreatedAt = new DateTime(2015, 7, 19, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2015, 7, 19, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("34343434-3434-3434-3434-343434343434"),
        QuoteText = "Every moment is a fresh beginning.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        CreatedAt = new DateTime(2005, 3, 11, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2005, 3, 11, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("56565656-5656-5656-5656-565656565656"),
        QuoteText = "What we think, we become.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        CreatedAt = new DateTime(1999, 9, 9, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(1999, 9, 9, 10, 0, 0, DateTimeKind.Utc)
    },
    new Quote
    {
        Id = Guid.Parse("78787878-7878-7878-7878-787878787878"),
        QuoteText = "Happiness depends upon ourselves.",
        UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        CreatedAt = new DateTime(2010, 12, 25, 10, 0, 0, DateTimeKind.Utc),
        UpdatedAt = new DateTime(2010, 12, 25, 10, 0, 0, DateTimeKind.Utc)
    }
);
    }
}
