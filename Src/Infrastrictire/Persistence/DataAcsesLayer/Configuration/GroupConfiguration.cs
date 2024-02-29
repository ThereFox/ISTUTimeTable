using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Name)
        .HasColumnType("varchar")
        .HasMaxLength(255);

        builder
        .Property(ex => ex.Speciality)
        .HasColumnType("text")
        .HasMaxLength(1024);

    }
}
