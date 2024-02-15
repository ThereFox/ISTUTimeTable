using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class AddUserInputObject
{
    [GraphQLNonNullType]
    public FullName FullName {get;}
    [GraphQLNonNullType]
    public string PublicIdentificator {get;}
    [GraphQLNonNullType]
    public int GroupId {get;}

    public AddUserInputObject(FullName fullName, string publicIdentificator, int groupId)
    {
        FullName = fullName;
        PublicIdentificator = publicIdentificator;
        GroupId = groupId;
    }
}
