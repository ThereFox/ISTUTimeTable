using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class WeeklySchedule
{
    public int Id { get; private set; }
    public int GroupId { get; private set; }

    public Group Group { get; private set; }

    public List<DayNums> DayNums { get; private set; }
}

