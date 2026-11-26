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

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "George Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
                new Author { Id = 2, Name = "J.R.R. Tolkien", DateOfBirth = new DateTime(1892, 1, 3) },
                new Author { Id = 3, Name = "Robert C. Martin", DateOfBirth = new DateTime(1952, 12, 5) }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", PublishedYear = 1949, AuthorId = 1 },
                new Book { Id = 2, Title = "The Hobbit", PublishedYear = 1937, AuthorId = 2 },
                new Book { Id = 3, Title = "Clean Code", PublishedYear = 2008, AuthorId = 3 }
            );
        }
    }
}
