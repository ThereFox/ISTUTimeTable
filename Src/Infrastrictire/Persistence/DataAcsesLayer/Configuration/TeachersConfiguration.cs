using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
{
    public void Configure(EntityTypeBuilder<Teachers> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder.Property(ex => ex.FirstName)
        .HasColumnType("varchar")
        .HasMaxLength(50);
    
        builder.Property(ex => ex.MiddleName)
        .HasColumnType("varchar")
        .HasMaxLength(50);
    
        builder.Property(ex => ex.LastName)
        .HasColumnType("varchar")
        .HasMaxLength(50);
    }
}
