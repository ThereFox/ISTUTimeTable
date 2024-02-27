using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<Lessons>
{
    public void Configure(EntityTypeBuilder<Lessons> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Subject)
        .WithMany(ex => ex.Lessons)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.SubjectId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasOne(ex => ex.Teacher)
        .WithMany(ex => ex.Lessons)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.TeacherId)
        .OnDelete(DeleteBehavior.SetNull);  

        builder
        .HasOne(ex => ex.Location)
        .WithMany(ex => ex.Lessons)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.LocationId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
