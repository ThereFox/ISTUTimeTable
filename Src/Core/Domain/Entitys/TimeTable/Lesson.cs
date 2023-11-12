using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.TimeTable;
using Entitys.Unpassings;

namespace ISTUTimeTable.Entitys
{
    public class Lesson
    {
        public TimeTableOnDay DayTimeTable { get;set; }

        public long id;

        public int SubjectId;
        public Subject Subject;

        public int TeacherId;
        public Teacher Teacher;
        public LessonType LessonType;
        public List<Group> Groups;

        public int LocationId;
        public Location Location;
        public List<Unpassing> Unpassings {get; set;}

    }
}
