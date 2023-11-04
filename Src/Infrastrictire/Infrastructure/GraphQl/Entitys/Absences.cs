using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Infrastruction.GraphQl.Entitys;

public class Absences
{
    public DateOnly Date;
    public List<UserInfo> ExpectedUsers { get; set; }
    public List<Absence> AbsencesUsers { get; set; }
}
