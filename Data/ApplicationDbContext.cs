using Microsoft.EntityFrameworkCore;
using UmbracoBlog.Data;

namespace Umbraco.Data
{

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public required DbSet<BlogPost> BlogPosts { get; set; }
    public required DbSet<Author> Authors { get; set; }
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        // Additional configuration using fluent API
        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.ToTable("blogPost");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            // Add more column mappings as needed
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            // Add more column mappings as needed
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            // Add more column mappings as needed
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            // Add more column mappings as needed
        });
    }
}
}