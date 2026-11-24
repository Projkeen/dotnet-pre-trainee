using LibraryManagementAPIwithEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPIwithEFCore.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
