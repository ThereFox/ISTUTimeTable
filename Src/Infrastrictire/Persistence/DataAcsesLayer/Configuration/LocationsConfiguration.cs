using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

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
