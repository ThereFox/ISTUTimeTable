using ISTUTimeTable.Src.Core.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

public class TimeTableOnWeekConfiguration : IEntityTypeConfiguration<TimeTableOnWeek>
{
    public void Configure(EntityTypeBuilder<TimeTableOnWeek> builder)
    {
        builder.ToTable("TimeTablesOnWeek");

        builder.HasKey(ex => ex.id);

        builder
        .HasOne(ex => ex.Monday)
        .WithOne(ex => ex.TimeTable)
        .HasForeignKey<TimeTableOnWeek>(ex => ex.MondayTimeTableId)
        .HasPrincipalKey<TimeTableOnDay>(ex => ex.Id);

        builder
        .HasOne(ex => ex.Tuesday)
        .WithOne(ex => ex.TimeTable)
        .HasForeignKey<TimeTableOnWeek>(ex => ex.TuesdayTimeTableId)
        .HasPrincipalKey<TimeTableOnDay>(ex => ex.Id);

        builder
        .HasOne(ex => ex.Wensday)
        .WithOne(ex => ex.TimeTable)
        .HasForeignKey<TimeTableOnWeek>(ex => ex.WensdayTimeTableId)
        .HasPrincipalKey<TimeTableOnDay>(ex => ex.Id);

        builder
        .HasOne(ex => ex.Thusday)
        .WithOne(ex => ex.TimeTable)
        .HasForeignKey<TimeTableOnWeek>(ex => ex.ThusdayTimeTableId)
        .HasPrincipalKey<TimeTableOnDay>(ex => ex.Id);

        builder
        .HasOne(ex => ex.Friday)
        .WithOne(ex => ex.TimeTable)
        .HasForeignKey<TimeTableOnWeek>(ex => ex.WensdayTimeTableId)
        .HasPrincipalKey<TimeTableOnDay>(ex => ex.Id);
        
        builder
        .HasOne(ex => ex.Group)
        .WithMany(ex => ex.TimeTablesOnWeeks)
        .HasForeignKey(ex => ex.GroupId)
        .HasPrincipalKey(ex => ex.Id);
    }
}
