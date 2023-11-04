using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace ISTUTimeTable.Infrastruction.GraphQl.Entitys;

public class UserInfo
{
    public int Id{get;set;}
    [GraphQLNonNullType]
    public string FullName{get;set;}
    [GraphQLNonNullType]
    public string Group {get;set;}
    public bool IsStudent {get;set;}
}
