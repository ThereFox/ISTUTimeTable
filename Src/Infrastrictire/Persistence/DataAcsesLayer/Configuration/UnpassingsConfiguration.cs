using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitys.Unpassings;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

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
        .HasForeignKey(ex => ex.Id);

        builder
        .HasOne<Lesson>(ex => ex.lesson)
        .WithMany(ex => ex.Unpassings)
        .HasForeignKey(ex => ex.Id);

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
