using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;

namespace ISTUTimeTable.Infrastruction.GraphQl.Querys;

public class AbsencesQuery
{
    private int test;

    public List<Absences> GetAbsences()
    {
        Console.WriteLine("tetetetet");

        return new List<Absences>(){
            new Absences(){ Date = DateOnly.MaxValue }
        };
    }
}
