using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Channels;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class ChannelConfiguration : IEntityTypeConfiguration<Channels>
{
    public void Configure(EntityTypeBuilder<Channels> builder)
    {
        builder.ToTable("Main.Сhannels");

        builder.HasKey(x => x.id);
    }
}
