using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcsesLayer.Configuration;

public class LocationsConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder
        .Property(ex => ex.FloorNumber)
        .HasColumnName("Floor");


        builder
        .Property(ex => ex.ClassRoomNumber)
        .HasColumnName("Class");


        builder
        .Property(ex => ex.CampusNumber)
        .HasColumnName("Campus");

        builder
        .HasMany(ex => ex.Lessons)
        .WithOne(ex => ex.Location)
        .HasForeignKey(ex => ex.LocationId)
        .HasPrincipalKey(ex => ex.id);

    }
}
