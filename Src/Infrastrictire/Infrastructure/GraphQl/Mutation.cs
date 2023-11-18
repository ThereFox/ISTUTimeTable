using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitys.Exceprions;
using GraphQl.Authorise.Attributes;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;

namespace GraphQl.Mutations;

public class Mutation
{
    private ITopicEventSender _notificationSender;

    public Mutation(ITopicEventSender sender)
    {
        _notificationSender = sender;
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateGroup")]
    [GraphQLDescription("Create Group (avaliable for admin)")]
    [Error(typeof(GroupAlreadyExistException))]
    public async Task AddGroup()
    {

        _notificationSender.SendAsync("");

    }
    
    [OnlyForAdminAuthorize]
    [GraphQLName("DropGroup")]
    [GraphQLDescription("Delete group (avaliable for admin)")]
    [Error(typeof(GroupDontHaveExistExcepiton))]
    public async Task DeleteGroup()
    {

    }

    [ForCorrectorAuthorize]
    [GraphQLName("AddWeekTimeTable")]
    [GraphQLDescription("Add timeTable for week")]
    public async Task AddTimeTableOnWeek()
    {

    }

    [ForCorrectorAuthorize]
    [GraphQLName("UpdateDayTimeTable")]
    [GraphQLDescription("Update time table on day (avaliable for admin and currector)")]
    public async Task UpdateTimeTableOnDay()
    {

    }

    [ForCorrectorAuthorize]
    [GraphQLName("UpdateLessonInfo")]
    [GraphQLDescription("update lesson info (avaliable for admin and currector)")]
    public async Task UpdateLessonInfo()
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("CreateComment")]
    [GraphQLDescription("Add comment to lesson")]
    [Error(typeof(UnacceptableTextException))]
    public async Task AddComment()
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of current user")]
    [Error(typeof(CommentCreatedByEnoutherUserException))]
    public async Task UpdateCommentFromCurrentUser(){}

    [OnlyForAdminAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of any user (avaliable for adnmin)")]
    [Error(typeof(CommentDontHaveExist))]
    public async Task UpdateComment()
    {

    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateUser")]
    [GraphQLDescription("Create user (avaliable for admin)")]
    [Error(typeof(UserAlreadyExistException))]
    public async Task CreateUser()
    {

    }

    [OnlyForAdminAuthorize]
    [GraphQLName("ChangeRole")]
    [GraphQLDescription("Change role of user (avaliable for admin)")]
    [Error(typeof(DontHaveUserException))]
    public async Task ChangeUserRole()
    {

    }

    [ForCorrectorAuthorize]
    [GraphQLName("ChangeGroup")]
    [GraphQLDescription("Change group of user (avaliable for admin and currector)")]
    [Error(typeof(DontHaveUserException))]
    public async Task ChangeUserGroup()
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of current user")]
    public async Task UpdateUnpassingForCurrentUser()
    {}
    
    [ForAnyAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of current user")]
    public async Task AddUnpassingForCurrentUser()
    {

    }
    
    [ForCorrectorAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of any user (avaliable for admin and currector)")]
    public async Task AddUnpassing()
    {

    }
    
    [ForCorrectorAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of any user (avaliable for admin and currector)")]
    public async Task UpdateUnpassing()
    {

    }

}
