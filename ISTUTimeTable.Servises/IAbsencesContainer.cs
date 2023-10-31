using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISTUTimeTable.Servises;

public interface IAbsencesContainer
{
    public void GetAbsencesInGroupByDay(DateOnly dateOnly, Group group);
}
