using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class AddUserInputObject
{
    [GraphQLNonNullType]
    public FullName fullName {get;set;}
    [GraphQLNonNullType]
    public string PublicIdentificator {get;set;}
    [GraphQLNonNullType]
    public int GroupId {get;set;}
}
