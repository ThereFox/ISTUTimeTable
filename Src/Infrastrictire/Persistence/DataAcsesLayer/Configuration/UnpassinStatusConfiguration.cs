using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class UnpassinStatusConfiguration : IEntityTypeConfiguration<UnpassingStatus>
{
    public void Configure(EntityTypeBuilder<UnpassingStatus> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Name)
        .HasColumnType("varchar")
        .HasMaxLength(50);

    }
}
