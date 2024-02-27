using Microsoft.EntityFrameworkCore;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using DataAcsesLayer.Entitys;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;

public class UsersDBContext : DbContext
{
    public DbSet<WeeklySchedule> WeeksTimeTables { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Unpassings> Unpassings { get; set; }
    public DbSet<RefreshableBearerRecord> Bearers { get; set; }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDBContext).Assembly);
    }

    public UsersDBContext(DbContextOptions<UsersDBContext> builder) : base(builder)
    {
    }
}