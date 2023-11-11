using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entitys.Unpassings;

public class UnpassingReason
{
    public string Reason { get; set; }
    public bool IsAvaliableReason { get; set; }
    public bool HaveAvaliableDocument { get; set; }
}
