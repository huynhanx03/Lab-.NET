using Microsoft.EntityFrameworkCore;
using ODataBookStore.Models;

namespace ODataBookStore
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) 
            : base(options)
        {
        }
        public DbSet<Press> Presses { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
        }
    }
}