using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class Location
{
    public int Id { get; private set; }
    public int CampusNumber { get; private set; }
    public int FloorNumber { get; private set; }
    public int CabinerNumber { get; private set; }

    public List<Lessons> Lessons { get; private set; }
}
