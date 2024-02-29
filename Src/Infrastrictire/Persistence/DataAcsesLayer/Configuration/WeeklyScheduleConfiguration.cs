using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class WeeklyScheduleConfiguration : IEntityTypeConfiguration<WeeklySchedule>
{
    public void Configure(EntityTypeBuilder<WeeklySchedule> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4");

        builder
        .HasOne(ex => ex.Group)
        .WithMany(ex => ex.Schedules)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.GroupId)
        .OnDelete(DeleteBehavior.Cascade);

    }
}
