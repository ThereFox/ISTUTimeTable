using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateGroupInputObject
{
    [GraphQLNonNullType]
    public int GroupId { get; }
    public string Speciality {get;}
    public int Cource {get;}

    public UpdateGroupInputObject(int groupId, string speciality, int cource)
    {
        GroupId = groupId;
        Speciality = speciality;
        Cource = cource;
    }

}
