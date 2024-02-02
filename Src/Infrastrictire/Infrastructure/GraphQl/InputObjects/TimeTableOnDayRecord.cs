using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class TimeTableOnDayRecord
{
    public LessonInputObject FirstLesson;
    public LessonInputObject SecondLesson;
    public LessonInputObject M2onday;
    public LessonInputObject M1onday;
    public LessonInputObject M3onday;
}
