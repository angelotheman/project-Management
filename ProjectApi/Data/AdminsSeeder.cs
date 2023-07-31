using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class AdminsSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Username = "angelotheman", Password = "facilityManager"},
                new User { Id = 2, Username = "arloo", Password = "estateManager"}
            );
        }
    }
}
