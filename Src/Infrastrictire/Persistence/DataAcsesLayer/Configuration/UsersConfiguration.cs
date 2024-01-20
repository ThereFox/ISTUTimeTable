using ISTUTimeTable.Src.Core.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder
        .ToTable("Users");

        builder
        .HasKey(ex => ex.Id);

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
        .HasForeignKey(ex => ex.GroupId)
        .HasPrincipalKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .Property(ex => ex.Role)
        .HasColumnType("Int32")
        .HasColumnName("Role");
    }
}
