using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.DataProvider.Configurations.Rel;

public class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
{
    public void Configure(EntityTypeBuilder<Departments> builder)
    {
        builder.ToTable("Rel.Departments");

        builder.HasKey(x=> x.id);

        builder.HasOne(x=>x.Administration)
            .WithMany(x => x.Department)
            .HasForeignKey(x => x.AdministrationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
