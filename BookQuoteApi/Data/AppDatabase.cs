using BookQuoteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookQuoteApi.Data
{
    public class AppDatabase
    {
        public AppDatabase(DbContextOptions<AppDatabase> options)
        : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}
