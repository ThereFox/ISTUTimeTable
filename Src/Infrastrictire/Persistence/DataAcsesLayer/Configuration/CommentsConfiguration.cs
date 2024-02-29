using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
{
    public void Configure(EntityTypeBuilder<Comments> builder)
    {
        builder.HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Message)
        .HasColumnType("text")
        .HasMaxLength(500);

        builder
        .Property(ex => ex.Date)
        .HasColumnType("timestamptz");

        builder
        .HasOne(ex => ex.Sender)
        .WithMany(ex => ex.Comments)
        .HasForeignKey(ex => ex.SenderId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Type)
        .WithMany(ex => ex.Comments)
        .HasForeignKey(ex => ex.TypeId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(ex => ex.LessonNum)
        .WithMany(ex => ex.Comments)
        .HasForeignKey(ex => ex.LessonNumId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.Cascade);


    }
}
