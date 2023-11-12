using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class Subject
    {
        public int Id;
        public string Name;

        public List<Lesson> Lessons;

    }
}
