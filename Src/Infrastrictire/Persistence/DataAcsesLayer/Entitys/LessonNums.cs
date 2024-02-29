using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class LessonNums
{
    public int Id { get; private set; }
    public int LessonNum { get; private set; }
    public int DailyScheduleId { get; private set; }
    public int LessonId { get; private set; }

    public DailySchedule DailySchedule { get; private set; }
    public Lessons Lesson { get; private set; }

    public List<Comments> Comments { get; private set; }
    public List<Unpassings> Unpassings { get; private set; }
}
