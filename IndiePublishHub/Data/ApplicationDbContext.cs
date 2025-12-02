using Microsoft.EntityFrameworkCore;
using IndiePublishHub.Models;

namespace IndiePublishHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("datetime('now')");
        }
    }
}