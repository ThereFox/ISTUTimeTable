using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddUnpassingInputObject
{
    [GraphQLNonNullType]
    public DateOnly Date {get;}
    [GraphQLNonNullType]
    public List<int> LessonsId {get;}
    [GraphQLNonNullType]
    public UnpassingReasonInputObject Reason {get;}
}
