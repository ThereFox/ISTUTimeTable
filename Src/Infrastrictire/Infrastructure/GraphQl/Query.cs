using System;
using System.Collections.Generic;
using System.Linq;
using App.Interfaces;
using Auth.Common;
using Entitys.Unpassings;
using GraphQl.Authorise.Attributes;
using ISTUTimeTable.Entitys;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;
using Src.Core.App.Interfaces;

namespace ISTUTimeTable.Infrastruction.GraphQl.Querys;

public class Query
{
    private ICurrentUserInfoGetter _currentUserInfo;
    private IUnpassingRepository _unpassings;
    private ITimeTableRepository _timeTables;
    private IUserAndGroupRepository _usersAndGroup;

    public Query(ICurrentUserInfoGetter currentUserInfoGetter, IUnpassingRepository unpassingRepository, ITimeTableRepository timeTableRepository, IUserAndGroupRepository userAndGroupRepository)
    {
        _currentUserInfo = currentUserInfoGetter;
        _unpassings = unpassingRepository;
        _timeTables = timeTableRepository;
        _usersAndGroup = userAndGroupRepository;
    }


    [ForAnyAuthorize]
    [GraphQLName("GetAbsences")]
    [GraphQLDescription("Get Absences from group of current user for concrete day")]
    public async Task<List<Unpassing>> GetUnpassingsFromCurronUserGroupByDay(DateOnly date)
    {
        var currentUserGroup = _currentUserInfo.GetGroupFromConcrectUser();
        var unpassing = await _unpassings.GetAllByDayAndGroup(currentUserGroup, date);
        
        return unpassing;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for group of current user")]
    // [Error(typeof(Exception))]///
    public async Task<TimeTableOnWeek> GetLastTimeTableOnWeekForCurrentUserGroup()
    {
        var currentUserGroup = _currentUserInfo.GetGroupFromConcrectUser();
        var lastTimeTable = await _timeTables.GetCurrentTimeTableOnWeekForGroup(currentUserGroup);

        // if(lastTimeTable.IsSucsesfull == false)
        // {
        //     throw new Exception("TimeTable for current week dont exist");
        // }


        return lastTimeTable.ResultValue;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for concrete group")]
    public async Task<TimeTableOnWeek> GetCurrentTimeTableOnWeekForGroup([ID]int groupId)
    {
        var group = _usersAndGroup.GetGroup(groupId);
        var lastTimeTable = await _timeTables.GetCurrentTimeTableOnWeekForGroup(group);

        if(lastTimeTable.IsSucsesfull == false)
        {
            throw new Exception("TimeTable for current week dont exist");
        }


        return lastTimeTable.ResultValue;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetInfoByUser")]
    [GraphQLDescription("Get info of user by id")]
    public async Task<User> GetInfoByUser([ID]int id)
    {
        await Task.CompletedTask;
        return _usersAndGroup.GetUser(id);
    }
    
    [ForAnyAuthorize]
    [GraphQLName("GetGroup")]
    [GraphQLDescription("Get Group by id")]
    public async Task<Group> GetGroup([ID] int id)
    {
        await Task.CompletedTask;
        return _usersAndGroup.GetGroup(id);
    }
}
