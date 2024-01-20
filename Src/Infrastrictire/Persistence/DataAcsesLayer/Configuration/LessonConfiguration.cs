using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");
        
        builder.HasOne(ex => ex.Subject)
        .WithMany(ex => ex.Lessons)
        .HasForeignKey(ex => ex.SubjectId)
        .HasPrincipalKey(ex => ex.Id);

        builder.HasOne(ex => ex.Teacher)
        .WithMany(ex => ex.Lessons)
        .HasForeignKey(ex => ex.TeacherId)
        .HasPrincipalKey(ex => ex.Id);

        builder
        .HasOne(ex => ex.Location)
        .WithMany(ex => ex.Lessons)
        .HasForeignKey(ex => ex.LocationId)
        .HasPrincipalKey(ex => ex.id);

        builder
        .Property(ex => ex.LessonType)
        .HasColumnName("Type");


    }
}
