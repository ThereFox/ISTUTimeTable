using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

public class CommentsConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);

        builder
        .HasOne(ex => ex.Writer)
        .WithMany(ex => ex.Comments)
        .HasForeignKey(ex => ex.WriterId)
        .HasPrincipalKey(ex => ex.Id);

        builder
        .HasOne(ex => ex.ForLesson)
        .WithMany(ex => ex.Comments)
        .HasForeignKey(ex => ex.LessonId)
        .HasPrincipalKey(ex => ex.id);

        builder
        .Property(ex => ex.Date)
        .HasColumnType("date")
        .HasColumnName("Date");

        builder.Property(ex => ex.Message).HasColumnName("Text");
        builder.Property(ex => ex.commentType).HasColumnName("Type");
        



    }
}
