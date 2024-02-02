using App.Interfaces;
using App.Interfaces.NotEnded;
using Authorise.Local.Interfaces;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using ISTUTimeTable.Src.Core.App.Interfaces;
using ISTUTimeTable.Src.Core.Domain.Exceptions;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;
using ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;
using Microsoft.AspNetCore.Http;
using ISTUTimeTable.Src.Core.App.DTO;
using GraphQl.InputObjects;
using Authorise.Common.Exceptions;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Mutations;

public class Mutation
{
    private ITopicEventSender _notificationSender;
    private IAuthService _authService;
    private ICommentsRepository _comments;
    private IGroupRepository _groups;
    private IUsersRepository _users;
    private ITimeTableRepository _timeTables;
    private IUnpassingRepository _unpassings;
    private HttpContextAccessor _acsessor;
    private ICurrentUserInfo _currentUserInfo; 

    public Mutation(ITopicEventSender sender)
    {
        _notificationSender = sender;
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateGroup")]
    [GraphQLDescription("Create Group (avaliable for admin)")]
    [Error(typeof(GroupAlreadyExistException))]
    public async Task AddGroup(AddGroupInputObject groupInput)
    {

    }

    [OnlyForAdminAuthorize]
    [GraphQLName("UpdateGroupInfo")]
    [GraphQLDescription("Update Group info (avaliable for admin)")]
    [Error(typeof(GroupAlreadyExistException))]
    public async Task UpdateGroupInfo(int baseGroupId, UpdateGroupInputObject update)
    {
        
    }

    
    [OnlyForAdminAuthorize]
    [GraphQLName("DropGroup")]
    [GraphQLDescription("Delete group (avaliable for admin)")]
    [Error(typeof(GroupAlreadyExistException))]
    public async Task DeleteGroup([ID] int id)
    {
        var result = await _groups.RemoveById(id);

        if(result.IsSucsesfull == false)
        {
            throw new GroupAlreadyExistException();
        }
    }

    [ForCorrectorAuthorize]
    [GraphQLName("AddWeekTimeTable")]
    [GraphQLDescription("Add timeTable for week")]
    public async Task AddTimeTableOnWeek(AddTimeTableOnWeekInputObject timeTable)
    {

    }

    [ForCorrectorAuthorize]
    [GraphQLName("UpdateDayTimeTable")]
    [GraphQLDescription("Update time table on day (avaliable for admin and currector)")]
    public async Task UpdateTimeTableOnWeek(UpdateTimeTableOnWeekInputObject update)
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("CreateComment")]
    [GraphQLDescription("Add comment to lesson")]
    [Error(typeof(UnacceptableTextException))]
    public async Task AddComment(AddCommentInputObject comment)
    {
        await Task.CompletedTask;
    }

    [ForAnyAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of current user")]
    [Error(typeof(CommentCreatedByEnoutherUserException))]
    public async Task UpdateCommentFromCurrentUser(UpdateCommentInputObject update){}

    [OnlyForAdminAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of any user (avaliable for adnmin)")]
    [Error(typeof(CommentDontHaveExist))]
    public async Task UpdateComment(UpdateCommentInputObject comment)
    {

    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateUser")]
    [GraphQLDescription("Create user (avaliable for admin)")]
    [Error(typeof(UserAlreadyExistException))]
    public async Task CreateUser(AddUserInputObject user)
    {

    }

    [OnlyForAdminAuthorize]
    [GraphQLName("ChangeUserInfo")]
    [GraphQLDescription("Change info of user (avaliable for admin)")]
    [Error(typeof(DontHaveUserException))]
    public async Task UpdateUserInfo(UpdateUserInputObject update)
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("ChangeGroup")]
    [GraphQLDescription("Change public info of user ")]
    [Error(typeof(DontHaveUserException))]
    public async Task ChangePublicUserInfoForCurrentUser(UpdatePublicUserInfoInputObject update)
    {

    }

    
    [ForAnyAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of current user")]
    public async Task AddUnpassingForCurrentUser(AddUnpassingInputObject unpassing)
    {

    }

    [ForAnyAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of current user")]
    public async Task UpdateUnpassingForCurrentUser(UpdateUnpassingForCurrentUserInputObject update)
    {}

    [ForCorrectorAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of any user (avaliable for admin and currector)")]
    public async Task AddUnpassing(AddUnpassingInputObject unpassing)
    {

    }
    
    [ForCorrectorAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of any user (avaliable for admin and currector)")]
    public async Task UpdateUnpassing(UpdateUnpassingFromCurrectorInputObject update)
    {

    }

    [AllowAnonymous]
    [GraphQLName("GenerateToken")]
    [GraphQLDescription("Generate auth token")]
    public async Task Auth(AuthInputObject authData)
    {
        var authInfo = new AuntificateInfo(authData.Login, authData.Password);
        var AuthResult = await _authService.Authification(authInfo);

        if(AuthResult.IsSucsesfull == false)
        {
            throw new Exception();
        }

        var tokens = AuthResult.ResultValue;

        _acsessor.HttpContext.Response.Headers["Token"] = tokens.AuthToken;
        _acsessor.HttpContext.Response.Cookies.Append("Refresh", tokens.RefreshToken, new CookieOptions() {HttpOnly = true} );
    }

}
