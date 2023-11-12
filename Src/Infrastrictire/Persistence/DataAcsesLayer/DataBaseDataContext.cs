using System.Reflection;
using DataAcsesLayer.Common.Interfaces;
using Entitys.Unpassings;
using ISTUTimeTable.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ISTUTImeTable.DataAcsesLayer;

internal class UsersDBContext : DbContext, ILowLevelDBData
{
    public DbSet<TimeTableOnWeek> WeeksTimeTables { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Unpassing> Unpassings { get; set; }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDBContext).Assembly);
    }
}