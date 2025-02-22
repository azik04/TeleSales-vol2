using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class CityConfiguration : IEntityTypeConfiguration<Cities>
{
    public void Configure(EntityTypeBuilder<Cities> builder)
    {
        builder.ToTable("List.Cities");

        builder.HasKey(x => x.id);
    
    }
}
