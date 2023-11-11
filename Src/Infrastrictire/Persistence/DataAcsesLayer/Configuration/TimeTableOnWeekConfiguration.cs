using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class TimeTableOnWeekConfiguration : IEntityTypeConfiguration<TimeTableOnWeek>
{
    public void Configure(EntityTypeBuilder<TimeTableOnWeek> builder)
    {
        builder.ToTable("TimeTablesOnWeek");
        builder.HasKey(ex => ex.id);

        builder
        .OwnsOne(ex => ex.Monday)
        .HasOne(ex => ex.TimeTable);

        builder
        .OwnsOne(ex => ex.Tuesday)
        .HasOne(ex => ex.TimeTable);

            builder
        .OwnsOne(ex => ex.Wensday)
        .HasOne(ex => ex.TimeTable);

        builder
        .OwnsOne(ex => ex.Thusday)
        .HasOne(ex => ex.TimeTable);

        builder
        .OwnsOne(ex => ex.Friday)
        .HasOne(ex => ex.TimeTable);

        // builder
        // .OwnsOne(ex => ex.)
        // .HasOne(ex => ex.TimeTable);

        builder
        .HasOne(ex => ex.Group)
        .WithMany(ex => ex);

        builder.Property(e => e.Group).HasColumnName("");
    }
}
