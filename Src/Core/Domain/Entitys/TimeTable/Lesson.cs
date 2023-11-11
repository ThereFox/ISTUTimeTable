using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.Unpassings;

namespace ISTUTimeTable.Entitys
{
    public class Lesson
    {
        public long id;
        public Subject Subject;
        public User Teacher;
        public LessonType LessonType;
        public List<Group> Groups;
        public Location Location;
        public List<Unpassing> Unpassings {get; set;}

    }
}
