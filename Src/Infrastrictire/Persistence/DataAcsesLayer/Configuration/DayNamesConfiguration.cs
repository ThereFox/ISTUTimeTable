using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class DayNamesConfiguration : IEntityTypeConfiguration<DayNames>
{
    public void Configure(EntityTypeBuilder<DayNames> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Name)
        .HasColumnType("varchar")
        .HasMaxLength(20);

        builder
        .HasMany(ex => ex.DayNums)
        .WithOne(ex => ex.DayName)
        .HasForeignKey(ex => ex.DayNameId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
