using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class UzadilmaConfiguration : IEntityTypeConfiguration<Uzadilmas>
{
    public void Configure(EntityTypeBuilder<Uzadilmas> builder)
    {
        builder.ToTable("Main.Uzadilmas");

        builder.HasKey(x => x.id);

        builder.HasOne(x => x.Сhannel)
            .WithMany(x => x.Uzadilma)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Region)
            .WithMany(x => x.Uzadilmas)
            .HasForeignKey(x => x.RegionId)
            .OnDelete(DeleteBehavior.Restrict);
    
        builder.HasOne(x => x.Department)
            .WithMany(x => x.Uzadilmas)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
