using Microsoft.EntityFrameworkCore;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }
        
        public DbSet<Report> Report { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship for Category and Report => One to Many
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Report)
                .WithOne(r => r.Category)
                .HasForeignKey(c => c.CategoryId);

            // Relationship for Status and Report => Many to Many
            modelBuilder.Entity<Status>()
                .HasMany(s => s.Report)
                .WithMany(c => c.Status)
                .UsingEntity(j => j.ToTable("ReportStatus"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
