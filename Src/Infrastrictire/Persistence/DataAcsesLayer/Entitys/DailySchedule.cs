using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class DailySchedule
{
    public int Id { get; private set; }
    public DateTime UpdateDate { get; private set; }

    public List<DayNums> DayNums { get; private set; }
    public List<LessonNums> LessonNums { get; private set; }
}
