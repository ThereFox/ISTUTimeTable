using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class Lessons
{
    public int Id { get; private set; }
    public int SubjectId { get; private set; }
    public int TeacherId { get; private set; }
    public int LocationId { get; private set; }

    public Subjects Subject { get; private set; }
    public Teachers Teacher { get; private set; }
    public Location Location { get; private set; }

    public List<LessonNums> LessonNums { get; private set; } 
}
