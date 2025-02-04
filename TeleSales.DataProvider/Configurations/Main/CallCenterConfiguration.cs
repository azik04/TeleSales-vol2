using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.DataProvider.Configurations.Main;

public class CallCenterConfiguration : IEntityTypeConfiguration<CallCenters>
{
    public void Configure(EntityTypeBuilder<CallCenters> builder)
    {
        builder.ToTable("Main.CallCenter");

        builder.HasKey(x => x.id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.CallCenter)
            .HasForeignKey(x => x.ExcludedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Сhannel)
            .WithMany(x => x.CallCenter)
            .HasForeignKey(x => x.СhannelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Region)
            .WithMany(x => x.CallCenters)
            .HasForeignKey(x => x.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApplicationType)
            .WithMany(x => x.CallCenters)
            .HasForeignKey(x => x.ApplicationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
           .WithMany(x => x.CallCenter)
           .HasForeignKey(x=> x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
