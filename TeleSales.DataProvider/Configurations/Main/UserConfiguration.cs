using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("Main.Users");

        builder.HasKey(x => x.id);

        builder.HasData(new Users
        {
            id = 1,
            Email = "admin@adra.gov.az",
            FullName = "Admin",
            Password = "Admin123",
            Role = Enums.Role.Admin,
            CreateAt = DateTime.Now,
            isDeleted = false,
        });
    }
}
