using Microsoft.EntityFrameworkCore;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Users> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminsSeeder());
        }
    }
}
