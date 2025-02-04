using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class ApplicationTypeConfiguration : IEntityTypeConfiguration<ApplicationTypes>
{
    public void Configure(EntityTypeBuilder<ApplicationTypes> builder)
    {
        builder.ToTable("List.ApplicationTypes");

        builder.HasKey(x => x.id);
    }
}
