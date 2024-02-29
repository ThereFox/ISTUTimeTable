using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class LessonTypes
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public List<Lessons> Lessons { get; private set; }
}
