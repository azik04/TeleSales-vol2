using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class SubResultConfiguration : IEntityTypeConfiguration<SubResults>
{
    public void Configure(EntityTypeBuilder<SubResults> builder)
    {
        builder.ToTable("List.SubResults");

        builder.HasKey(x => x.id);

        builder.HasOne(x => x.Results)
            .WithMany(x => x.SubResults)
            .HasForeignKey(x => x.ResultId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
