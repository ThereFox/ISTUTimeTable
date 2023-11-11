using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;

namespace ISTUTimeTable.Infrastruction.GraphQl.Mutations;

public class AbsencesMutations
{
    public async Task<bool> TryAddAbsences(Absences absences)
    {
        await Task.CompletedTask;
        return true;
    }
}
