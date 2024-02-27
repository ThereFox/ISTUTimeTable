using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class DayNums
{
    public int Id { get; private set; }
    
    public int WeekId { get; private set; }
    public int DailyScheduleId { get; private set; }
    public int DayNameId { get; private set; }

    public WeeklySchedule Week { get; private set; }
    public DailySchedule DailySchedule { get; private set; }
    public DayNames DayName { get; private set; }

}
