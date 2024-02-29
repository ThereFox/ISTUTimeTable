using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class Unpassings
{
    public int Id { get;private set; }
    public DateOnly DateOfInforming { get; private set; }
    public int StudentId { get; private set; }
    public int LessonNumId { get; private set; }
    public int StatusId { get; private set; } 

    public User Student { get; private set; }
    public LessonNums lessonNum { get; private set; }
    public UnpassingStatus Status { get; private set; }

}
