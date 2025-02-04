using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class UserChannelConfiguration : IEntityTypeConfiguration<UserChannels>
{
    public void Configure(EntityTypeBuilder<UserChannels> builder)
    {
        builder.ToTable("Main.UserChannels");

        builder.HasKey(x => x.id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserChannel)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Сhannel)
            .WithMany(x => x.UserChannel)
            .HasForeignKey(x => x.СhannelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
