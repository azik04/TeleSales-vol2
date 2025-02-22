using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class StatusConfiguration : IEntityTypeConfiguration<Statuses>
{
    public void Configure(EntityTypeBuilder<Statuses> builder)
    {
        builder.ToTable("List.Statuses");

        builder.HasKey(x => x.id);
    }
}
