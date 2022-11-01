using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<ReservBook> ReservBooks { get; set; }
        public DataContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=bookapp.db");
        }
    }
}
