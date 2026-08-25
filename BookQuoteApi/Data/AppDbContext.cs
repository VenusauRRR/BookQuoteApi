using BookQuoteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}
