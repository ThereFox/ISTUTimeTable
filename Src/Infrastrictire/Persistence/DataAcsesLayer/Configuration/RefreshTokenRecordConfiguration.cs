using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;
using Authorise.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class RefreshTokenRecordConfiguration : IEntityTypeConfiguration<RefreshableBearerRecord>
{
    public void Configure(EntityTypeBuilder<RefreshableBearerRecord> builder)
    {
        builder.HasKey(x => x.Id);
        // builder
        // .HasOne(ex => ex.UserId)
        // .WithMany(ex => ex.)
    }
}
