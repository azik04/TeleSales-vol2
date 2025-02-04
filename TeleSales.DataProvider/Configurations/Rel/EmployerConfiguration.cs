using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.DataProvider.Configurations.Rel;

public class EmployerConfiguration : IEntityTypeConfiguration<Employers>
{
    public void Configure(EntityTypeBuilder<Employers> builder)
    {
        builder.ToTable("Rel.Employers");
        
        builder.HasKey(x => x.id);

        builder.HasOne(x => x.Department)
           .WithMany(x => x.Employer)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
