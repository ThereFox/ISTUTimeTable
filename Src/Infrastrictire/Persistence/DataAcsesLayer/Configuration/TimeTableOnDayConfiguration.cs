using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class TimeTableOnDayConfiguration : IEntityTypeConfiguration<TimeTableOnDay>
{
    public void Configure(EntityTypeBuilder<TimeTableOnDay> builder)
    {
        builder.ToTable("TimeTableOnDay");

        builder
        .HasKey(ex => ex.Id);
        
        builder
        .Property(ex => ex.Date)
        .HasColumnType("date")
        .HasColumnName("Date");

        builder
        .HasOne(ex => ex.FirstLesson)
        .WithOne(ex => ex.DayTimeTable)
        .HasForeignKey<TimeTableOnDay>(ex => ex.FirstLessonId)
        .HasPrincipalKey<Lesson>(ex => ex.id);

        builder
        .HasOne(ex => ex.SecondLesson)
        .WithOne(ex => ex.DayTimeTable)
        .HasForeignKey<TimeTableOnDay>(ex => ex.SecondLessonId)
        .HasPrincipalKey<Lesson>(ex => ex.id);

        builder
        .HasOne(ex => ex.ThrigthLesson)
        .WithOne(ex => ex.DayTimeTable)
        .HasForeignKey<TimeTableOnDay>(ex => ex.ThrigthLessonId)
        .HasPrincipalKey<Lesson>(ex => ex.id);

        builder
        .HasOne(ex => ex.FourthLesson)
        .WithOne(ex => ex.DayTimeTable)
        .HasForeignKey<TimeTableOnDay>(ex => ex.FourthLessonId)
        .HasPrincipalKey<Lesson>(ex => ex.id);

        builder
        .HasOne(ex => ex.FivethLesson)
        .WithOne(ex => ex.DayTimeTable)
        .HasForeignKey<TimeTableOnDay>(ex => ex.FivethLessonId)
        .HasPrincipalKey<Lesson>(ex => ex.id);

    }
}
