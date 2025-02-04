using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class ResultConfiguration : IEntityTypeConfiguration<Results>
{
    public void Configure(EntityTypeBuilder<Results> builder)
    {
        builder.ToTable("List.CallResult");

        builder.HasKey(x => x.id);
    }
}
