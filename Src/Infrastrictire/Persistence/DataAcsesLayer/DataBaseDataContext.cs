using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ISTUTImeTable.DataAcsesLayer;

public class UsersDBContext : DbContext
{
    /// <summary>
    /// tetete
    /// </summary>
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}