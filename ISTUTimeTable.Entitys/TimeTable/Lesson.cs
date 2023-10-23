using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class Lesson
    {
        public long id;
        public Subject Subject;
        public Teacher teacher;
        public LessonType LessonType;
        public List<Group> Groups;

    }
}
