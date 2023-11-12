using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Entitys.Unpassings;
using ISTUTimeTable.Entitys;

namespace DataAcsesLayer.Common.Interfaces;

internal interface ILowLevelDBData
{
    public DbSet<TimeTableOnWeek> WeeksTimeTables { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Unpassing> Unpassings { get; set; }
}
