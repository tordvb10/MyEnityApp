using Microsoft.EntityFrameworkCore;
using MyEnityApp.Models;

namespace MyEnityApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");  // Set precision and scale

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Create new enity classes for the modelBuilders below.

            modelBuilder.Entity<Parent>()
                .HasKey(p => p.ParentId);

            modelBuilder.Entity<Child>()
                .HasKey(c => c.ChildId);

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Child)               // One-to-One or One-to-Many
                .WithMany(p => p.Parents)           // One-to-Many or Many-to-One
                .HasForeignKey(p => p.ChildId);     // Foreign Key

            // new classes

            modelBuilder.Entity<Author>()
                .HasKey(a => a.AuthorId);

            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookId);

            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            // Define the One-to-One Relationship
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Biography)
                .WithOne(b => b.Author)
                .HasForeignKey<AuthorBiography>(b => b.AuthorId);

            // Define the One-to-Many Relationship
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // Define the Many-to-One Relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            // Define the Many-to-One Relationship

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the cascade behavior for AuthorBook -> Author relationship


            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the cascade behavior for AuthorBook -> Author relationship


            modelBuilder.Entity<AuthorBiography>()
                .HasKey(ab => ab.AuthorBiographyId); // Define the primary key

            base.OnModelCreating(modelBuilder);
        }
    }
}
