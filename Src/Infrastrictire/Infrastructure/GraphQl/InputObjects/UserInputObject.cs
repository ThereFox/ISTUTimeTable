using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UserInputObject
{
    public FullName fullName {get;set;}
    public string PublicIdentificator {get;set;}
    [GraphQLNonNullType]
    public int GroupId {get;set;}
}
