using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class TimeTableNode
    {
        public int Id;
        public DateOnly Date;
        public TimeTable TimeTable;
        public Lesson FirstLesson;
        public Lesson SecondLesson;
        public Lesson ThrigthLesson;
        public Lesson FourthLesson;
        public Lesson FivethLesson;
    }
}
