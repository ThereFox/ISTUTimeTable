using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class TimeTableOnDay
    {
        public int Id;
        public DateOnly Date;
        
        public TimeTableOnWeek TimeTable;

        public int FirstLessonId;
        public Lesson FirstLesson;

        public int SecondLessonId;
        public Lesson SecondLesson;

        public int ThrigthLessonId;
        public Lesson ThrigthLesson;

        public int FourthLessonId;
        public Lesson FourthLesson;

        public int FivethLessonId;
        public Lesson FivethLesson;
    }
}
