using Books_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Title).HasMaxLength(150).IsRequired();
                entity.Property(p => p.description).HasMaxLength(1000);
                entity.Property(p => p.price).HasPrecision(10, 2);
                entity.Property(p => p.status).HasMaxLength(20).IsRequired();
                entity.Property(p => p.image).HasMaxLength(500);
            });
        }
    }
}
