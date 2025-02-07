using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class DebitorConfiguration : IEntityTypeConfiguration<Debitors>
{
    public void Configure(EntityTypeBuilder<Debitors> builder)
    {
        builder.ToTable("Main.Debitors");

        builder.HasKey(x => x.id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Debitor)
            .HasForeignKey(x => x.ExcludedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Сhannel)
            .WithMany(x => x.Debitor)
            .HasForeignKey(x=> x.ChannelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Result)
            .WithMany(x => x.Debitors)
            .HasForeignKey(x=>x.ResultId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany(x => x.Debitors)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
