using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateUnpassingFromCurrectorInputObject
{
    public class UpdateUnpassingForCurrentUserInputObject
{
    [GraphQLNonNullType]
    public int UnpassingId {get;}
    public List<int> LessonsId {get;}
    public UnpassingReasonInputObject Reason {get;}
}
}
