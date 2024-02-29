using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class Group
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Cource { get; private set; }
    public string Speciality { get; private set; }

    public List<WeeklySchedule> Schedules { get; private set; }
    public List<User> Users { get; private set; }
}
