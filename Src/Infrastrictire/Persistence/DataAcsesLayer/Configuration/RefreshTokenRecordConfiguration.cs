using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Configuration;

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
