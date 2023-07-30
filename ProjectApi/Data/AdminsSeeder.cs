using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class AdminsSeeder : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(
                new Users { Id = 1, Username = "angelotheman", Password = "facilityManager"},
                new Users { Id = 2, Username = "arloo", Password = "estateManager"}
            );
        }
    }
}
