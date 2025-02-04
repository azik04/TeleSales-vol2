using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class ChannelConfiguration : IEntityTypeConfiguration<Сhannels>
{
    public void Configure(EntityTypeBuilder<Сhannels> builder)
    {
        builder.ToTable("Main.Сhannels");

        builder.HasKey(x => x.id);
    }
}
