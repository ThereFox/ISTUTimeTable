using System;
using System.Collections.Generic;
using System.Linq;
using Auth.Common;
using GraphQl.Authorise.Attributes;
using ISTUTimeTable.Entitys;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;

namespace ISTUTimeTable.Infrastruction.GraphQl.Querys;

public class Query
{
    [ForAnyAuthorize]
    [GraphQLName("GetAbsences")]
    [GraphQLDescription("Get Absences from group of current user for concrete day")]
    public async Task<List<Absences>> GetAbsencesFromCurronUserGroupByDay(DateOnly date)
    {
        Console.WriteLine("tetetetet");

        return new List<Absences>(){
            new Absences(){ Date = DateOnly.MaxValue }
        };
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for group of current user")]
    public async Task<TimeTableOnWeek> GetCurrentTimeTableOnWeekForCurrentUserGroup()
    {
        throw new NotImplementedException();
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for concrete group")]
    public async Task<TimeTableOnWeek> GetCurrentTimeTableOnWeekForGroup([ID]int groupId)
    {
        throw new NotImplementedException();
    }

    [ForAnyAuthorize]
    [GraphQLName("GetInfoByUser")]
    [GraphQLDescription("Get info of user by id")]
    public async Task<User> GetInfoByUser([ID]int id)
    {
        throw new NotImplementedException();
    }
    
    [ForAnyAuthorize]
    [GraphQLName("GetGroup")]
    [GraphQLDescription("Get Group by id")]
    public async Task<Group> GetGroup([ID] int id)
    {
        throw new NotImplementedException();
    }

    [GraphQLName("GenerateToken")]
    [GraphQLDescription("Generate auth token")]
    public async Task<AuthBearer> Auth()
    {
        throw new NotImplementedException();
    }
}
