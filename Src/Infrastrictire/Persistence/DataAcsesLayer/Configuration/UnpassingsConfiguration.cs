using ISTUTimeTable.Src.Core.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

public class UnpassingsConfiguration : IEntityTypeConfiguration<Unpassing>
{
    public void Configure(EntityTypeBuilder<Unpassing> builder)
    {
        
        builder.
        ToTable("Unpassings");

        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.InformingDate)
        .HasColumnType("date")
        .HasColumnName("InformingDate");

        builder
        .HasOne<User>(ex => ex.Student)
        .WithMany(ex => ex.Unpassings)
        .HasForeignKey(ex => ex.StudentId)
        .HasPrincipalKey(ex => ex.Id);

        builder
        .HasOne<Lesson>(ex => ex.lesson)
        .WithMany(ex => ex.Unpassings)
        .HasForeignKey(ex => ex.LessonId)
        .HasPrincipalKey(ex => ex.id);

        builder
        .Property(ex => ex.Reason.Reason)
        .HasColumnName("ReasonTitle");

        builder
        .Property(ex => ex.Reason.HaveAvaliableDocument)
        .HasColumnName("HaveAvaliableDocument");


        builder
        .Property(ex => ex.Reason.IsAvaliableReason)
        .HasColumnName("ReasonIsAvaliable");

    }
}
