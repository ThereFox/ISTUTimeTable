using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace Entitys.Unpassings;

public class Unpassing
{
    public int Id { get; set; }
    public DateOnly InformingDate { get; set; }
    public TimeTableOnDay Day { get; set; }
    public User Student { get;set; }
    public Lesson lesson { get; set; }
    public UnpassingReason Reason { get; set;}
}
