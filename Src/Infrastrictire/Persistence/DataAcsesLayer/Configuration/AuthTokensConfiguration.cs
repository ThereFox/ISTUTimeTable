using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class AuthTokensConfiguration : IEntityTypeConfiguration<AuthTokens>
{
    public void Configure(EntityTypeBuilder<AuthTokens> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int4")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.LiveBefore)
        .HasColumnType("timestamptz");

        builder
        .HasOne(ex => ex.Owner)
        .WithMany(ex => ex.Tokens)
        .HasForeignKey(ex => ex.OwnerId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.Cascade);

    }
}
