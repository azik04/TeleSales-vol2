﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleSales.DataProvider.Entities.List;

namespace TeleSales.DataProvider.Configurations.List;

public class RegionConfiguration : IEntityTypeConfiguration<Regions>
{
    public void Configure(EntityTypeBuilder<Regions> builder)
    {
        builder.ToTable("List.Regions");

        builder.HasKey(x => x.id);
    }
}
