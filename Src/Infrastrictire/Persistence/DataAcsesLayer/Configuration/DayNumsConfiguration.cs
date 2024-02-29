using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class DayNumsConfiguration : IEntityTypeConfiguration<DayNums>
{
    public void Configure(EntityTypeBuilder<DayNums> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Week)
        .WithMany(ex => ex.DayNums)
        .HasForeignKey(ex => ex.WeekId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.DailySchedule)
        .WithMany(ex => ex.DayNums)
        .HasForeignKey(ex => ex.DailyScheduleId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasOne(ex => ex.DayName)
        .WithMany(ex => ex.DayNums)
        .HasForeignKey(ex => ex.DayNameId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.SetNull);    
    }
}
