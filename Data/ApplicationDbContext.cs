using Project_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects => Set<Project>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).HasMaxLength(150).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(2000);
                entity.Property(p => p.Budget).HasPrecision(12, 2);
                entity.Property(p => p.Status).HasMaxLength(30).IsRequired();
                entity.Property(p => p.Priority).HasMaxLength(20).IsRequired();
                entity.Property(p => p.ProjectManager).HasMaxLength(120);
            });
        }
    }
}