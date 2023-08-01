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
        public DbSet<ReportStatus> ReportStatus { get; set; }

        /*
        public List<ManualUser> PredefinedUsers { get; set; } = new List<ManualUser>
        {
            new ManualUser { Username = "facilitymanager", Password = "facility001"},
            new ManualUser { Username = "estatemanager", Password = "estate001"}
        };*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship for User and Report => One to Many
            modelBuilder.Entity<User>()
                .HasMany(u => u.Report)
                .WithOne(r => r.User)
                .HasForeignKey(u => u.UserId);

            // Relationship for Category and Report => One to Many
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Report)
                .WithOne(r => r.Category)
                .HasForeignKey(c => c.CategoryId);

            // Relationship for Status and Report => Many to Many
            modelBuilder.Entity<Status>()
                .HasMany(s => s.Report)
                .WithMany(c => c.Status);

            base.OnModelCreating(modelBuilder);
        }
    }
}
