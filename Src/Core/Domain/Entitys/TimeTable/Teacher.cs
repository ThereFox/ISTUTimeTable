using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace Entitys.TimeTable;

public class Teacher
{
    public int Id;
    public FullName Name;

    public List<Lesson> Lessons {get;set;}
}
