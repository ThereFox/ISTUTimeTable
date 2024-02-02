using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddGroupInputObject
{
    [GraphQLNonNullType]
    public string Speciality {get;set;}
    [GraphQLNonNullType]
    public int Cource {get;set;}
}
