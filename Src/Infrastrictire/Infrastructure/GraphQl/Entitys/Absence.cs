using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace ISTUTimeTable.View.GraphQl.Entitys;

public class Absence
{
    public UserInfo User { get; set; }
    [GraphQLNonNullType]
    public string Reason { get; set; }
    public bool IsValidReason{ get; set; }
    public bool NeedConfurm { get; set; }
}
