using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.DataProvider.Configurations.Rel;

public class AdministrationConfiguration : IEntityTypeConfiguration<Administrations>
{
    public void Configure(EntityTypeBuilder<Administrations> builder)
    {
        builder.ToTable("Rel.Administrations");

        builder.HasKey(x => x.id);
    }
}
