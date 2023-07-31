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
        public List<ManualUser> PredefinedUsers { get; set; } = new List<ManualUser>
        {
            new ManualUser { Username = "facilitymanager", Password = "facility001"},
            new ManualUser { Username = "estatemanager", Password = "estate001"}
        };
    }
}
