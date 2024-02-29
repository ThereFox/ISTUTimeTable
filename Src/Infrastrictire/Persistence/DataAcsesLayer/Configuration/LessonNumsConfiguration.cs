using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class LessonNumsConfiguration : IEntityTypeConfiguration<LessonNums>
{
    public void Configure(EntityTypeBuilder<LessonNums> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.LessonNum)
        .HasColumnType("int4");

        builder
        .HasOne(ex => ex.DailySchedule)
        .WithMany(ex => ex.LessonNums)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.DailyScheduleId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasOne(ex => ex.Lesson)
        .WithMany(ex => ex.LessonNums)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.LessonId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
