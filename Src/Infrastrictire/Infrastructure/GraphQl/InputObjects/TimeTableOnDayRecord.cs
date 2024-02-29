using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class TimeTableOnDayRecord
{
    public LessonInputObject FirstLesson { get; }
    public LessonInputObject SecondLesson { get; }
    public LessonInputObject ThridthLesson { get; }
    public LessonInputObject FourthLesson { get; }
    public LessonInputObject FivethLesson { get; }

    public TimeTableOnDayRecord(
        LessonInputObject firstLesson,
        LessonInputObject secondLesson,
        LessonInputObject thridthLesson,
        LessonInputObject fourthLesson,
        LessonInputObject fivethLesson
        )
    {
        FirstLesson = firstLesson;
        SecondLesson = secondLesson;
        ThridthLesson = thridthLesson;
        FourthLesson = fourthLesson;
        FivethLesson = fivethLesson;
    }
}
