using App.Interfaces;
using App.Interfaces.NotEnded;
using ISTUTimeTable.Src.Core.App.Interfaces;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Querys;

public class Query
{
    private IGroupRepository _groups;
    private IUsersRepository _users;
    private ITimeTableRepository _timeTables;
    private IUnpassingRepository _unpassings;

    private ICurrentUserInfo _currentUserInfo; 

    public Query(
        IGroupRepository groupRepository,
        IUnpassingRepository unpassingRepository,
        ITimeTableRepository timeTableRepository,
        IUsersRepository usersRepository,
        ICurrentUserInfo currentUserInfo)
    {
        _currentUserInfo = currentUserInfo;
        _groups = groupRepository;
        _users = usersRepository;
        _timeTables = timeTableRepository;
        _unpassings = unpassingRepository;
    }


    [ForAnyAuthorize]
    [GraphQLName("GetAbsences")]
    [GraphQLDescription("Get Absences from group of current user for concrete day")]
    public async Task<List<Unpassing>> GetUnpassingsFromCurronUserGroupByDay(DateOnly date)
    {
        var currentUser = await _currentUserInfo.Get();

        if(currentUser.IsSucsesfull == false)
        {
            throw new Exception();
        }

        var unpassing = await _unpassings.GetByGroupAndDate(currentUser.ResultValue.Id, date);
        
        return unpassing.ResultValue;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for group of current user")]
    // [Error(typeof(Exception))]///
    public async Task<TimeTableOnWeek> GetCurrentTimeTableOnWeekForCurrentUserGroup()
    {
        var currentUserGroup = await _currentUserInfo.Get();

        if(currentUserGroup.IsSucsesfull == false)
        {
            throw new Exception();
        }

        var TimeTable = await _timeTables.GetCurrentByGroupId(currentUserGroup.ResultValue.GroupId);

        if(TimeTable.IsSucsesfull == false)
        {
            throw new Exception();
        }

            return TimeTable.ResultValue;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetTimeTableOnWeek")]
    [GraphQLDescription("Get Timetable for concrete group")]
    public async Task<TimeTableOnWeek> GetCurrentTimeTableOnWeekForGroup(int groupId)
    {
        var TimeTable = await _timeTables.GetCurrentByGroupId(groupId);
        if(TimeTable.IsSucsesfull == false)
        {
            throw new Exception();
        }
        return TimeTable.ResultValue;
    }

    [ForAnyAuthorize]
    [GraphQLName("GetInfoByUser")]
    [GraphQLDescription("Get info of user by id")]
    public async Task<User> GetInfoByUser([ID]int id)
    {
        var user = await _users.GetById(id);

        if(user.IsSucsesfull == false)
        {
            throw new Exception();
        }

        return user.ResultValue;
    }
    
    [ForAnyAuthorize]
    [GraphQLName("GetGroup")]
    [GraphQLDescription("Get Group by id")]
    public async Task<Group> GetGroup([ID] int id)
    {
        var group = await _groups.GetById(id);

        if(group.IsSucsesfull == false)
        {
            throw new Exception();
        }

        return group.ResultValue;
    }
    
    [ForAnyAuthorize]
    [GraphQLName("GetAllGroups")]
    [GraphQLDescription("Get all Group by scheme")]
    public async Task<List<Group>> GetAllGroups()
    {
        throw new Exception();
    }

    [ForAnyAuthorize]
    [GraphQLName("GetAllUsers")]
    [GraphQLDescription("Get all users by sceme")]
    public async Task<List<User>> GetAllUsers()
    {
        throw new Exception();
    }
    public async Task GetAllSubjects()
    {
        throw new Exception();
    }
    public async Task GetAllTeachers()
    {
        throw new Exception();
    }
    public async Task GetAllLocation()
    {
        throw new Exception();
    }
}
