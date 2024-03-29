using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.InputObjects;

public class UpdateUnpassingForCurrentUserInputObject
{
    [GraphQLNonNullType]
    public DateOnly Date {get;}
    public List<int> LessonsId {get;}
    public UnpassingReasonInputObject Reason {get;}
}
