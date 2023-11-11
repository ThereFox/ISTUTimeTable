using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder
        .ToTable("Users");

        builder
        .HasKey(ex => ex.Id)
        .HasColumnName("Id");

        builder
        .Property(ex => ex.Name.FirstName)
        .HasColumnName("FirstName")
        .HasMaxLength(20);

        builder
        .Property(ex => ex.Name.MiddleName)
        .HasColumnName("MiddleName")
        .HasMaxLength(20);

        builder
        .Property(ex => ex.Name.LastName)
        .HasColumnName("LastName")
        .HasMaxLength(20);

        builder
        .HasOne<Group>((ex) => ex.group)
        .WithMany(ex => ex.Students)
        .HasForeignKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .Property(ex => ex.Role)
        .HasColumnType("Int32")
        .HasColumnName("Role");
    }
}
