using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class UnpassingsConfiguration : IEntityTypeConfiguration<Unpassings>
{
    public void Configure(EntityTypeBuilder<Unpassings> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.DateOfInforming)
        .HasColumnType("date");

        builder
        .HasOne(ex => ex.Student)
        .WithMany(ex => ex.Unpassings)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.StudentId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.lessonNum)
        .WithMany(ex => ex.Unpassings)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.LessonNumId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Status)
        .WithMany(ex => ex.Unpassings)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.StatusId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
