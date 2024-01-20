using Microsoft.EntityFrameworkCore;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;

internal class UsersDBContext : DbContext
{
    public DbSet<TimeTableOnWeek> WeeksTimeTables { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Unpassing> Unpassings { get; set; }
    public DbSet<RefreshableBearerRecord> Bearers { get; set; }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDBContext).Assembly);
    }
}