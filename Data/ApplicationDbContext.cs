// Data/ApplicationDbContext.cs

// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace UmbracoBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } // Add DbSet for your model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Optional: Additional model configurations
        }
    }
}