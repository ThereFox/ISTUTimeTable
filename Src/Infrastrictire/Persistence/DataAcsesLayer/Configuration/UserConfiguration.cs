using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
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

        builder
        .HasOne(ex => ex.Group)
        .WithMany(ex => ex.Users)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.GroupId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Role)
        .WithMany(ex => ex.Users)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.RoleId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
