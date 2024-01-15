using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitys.Unpassings;

namespace ISTUTimeTable.Infrastruction.GraphQl.Entitys;

public class Absences
{
    public DateOnly Date {get;set;}
    public List<Unpassing> AbsencesUsers { get; set; }
}
