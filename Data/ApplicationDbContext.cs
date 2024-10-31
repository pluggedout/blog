// Data/ApplicationDbContext.cs

// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace UmbracoBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many relationship between BlogPost and Category
            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Categories)
                .WithMany(c => c.BlogPosts);

            // One-to-many relationship between BlogPost and Comment
            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId);

            // One-to-many relationship between Author and BlogPost
            modelBuilder.Entity<Author>()
                .HasMany(a => a.BlogPosts)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
