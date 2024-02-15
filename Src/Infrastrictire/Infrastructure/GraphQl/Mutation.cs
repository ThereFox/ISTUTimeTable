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
using GraphQl.Responses;
using ISTUTimeTable.Src.Core.Common;
using static ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects.UpdateUnpassingFromCurrectorInputObject;

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
    private IHttpContextAccessor _acsessor;
    private ICurrentUserInfo _currentUserInfo; 

    public Mutation(
        ITopicEventSender sender,
        IAuthService authService,
        IHttpContextAccessor accessor
        )
    {
        _authService = authService;
        _notificationSender = sender;
        _acsessor = accessor;
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateGroup")]
    [GraphQLDescription("Create Group (avaliable for admin)")]
    //[Error(typeof(GroupAlreadyExistException))]
    public async Task<DefaultActionResponse> AddGroup(AddGroupInputObject groupInput)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("UpdateGroupInfo")]
    [GraphQLDescription("Update Group info (avaliable for admin)")]
    //[Error(typeof(GroupAlreadyExistException))]
    public async Task<DefaultActionResponse> UpdateGroupInfo(int baseGroupId, UpdateGroupInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    
    [OnlyForAdminAuthorize]
    [GraphQLName("DropGroup")]
    [GraphQLDescription("Delete group (avaliable for admin)")]
    //[Error(typeof(GroupAlreadyExistException))]
    public async Task<DefaultActionResponse> DeleteGroup([ID] int id)
    {
        var result = await _groups.RemoveById(id);

        if(result.IsSucsesfull == false)
        {
            throw new GroupAlreadyExistException();
        }
        return DefaultActionResponse.FromResult(result);
    }

    [ForCorrectorAuthorize]
    [GraphQLName("AddWeekTimeTable")]
    [GraphQLDescription("Add timeTable for week")]
    public async Task<DefaultActionResponse> AddTimeTableOnWeek(AddTimeTableOnWeekInputObject timeTable)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [ForCorrectorAuthorize]
    [GraphQLName("UpdateDayTimeTable")]
    [GraphQLDescription("Update time table on day (avaliable for admin and currector)")]
    public async Task<DefaultActionResponse> UpdateTimeTableOnWeek(UpdateTimeTableOnWeekInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [ForAnyAuthorize]
    [GraphQLName("CreateComment")]
    [GraphQLDescription("Add comment to lesson")]
    //[Error(typeof(UnacceptableTextException))]
    public async Task<DefaultActionResponse> AddComment(AddCommentInputObject comment)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [ForAnyAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of current user")]
    //[Error(typeof(CommentCreatedByEnoutherUserException))]
    public async Task<DefaultActionResponse> UpdateCommentFromCurrentUser(UpdateCommentInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("UpdateComment")]
    [GraphQLDescription("Update comment of any user (avaliable for adnmin)")]
    //[Error(typeof(CommentDontHaveExist))]
    public async Task<DefaultActionResponse> UpdateComment(UpdateCommentInputObject comment)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("CreateUser")]
    [GraphQLDescription("Create user (avaliable for admin)")]
    //[Error(typeof(UserAlreadyExistException))]
    public async Task<DefaultActionResponse> CreateUser(AddUserInputObject user)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [OnlyForAdminAuthorize]
    [GraphQLName("ChangeUserInfo")]
    [GraphQLDescription("Change info of user (avaliable for admin)")]
    //[Error(typeof(DontHaveUserException))]
    public async Task<DefaultActionResponse> UpdateUserInfo(UpdateUserInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [ForAnyAuthorize]
    [GraphQLName("ChangeGroup")]
    [GraphQLDescription("Change public info of user ")]
    //[Error(typeof(DontHaveUserException))]
    public async Task<DefaultActionResponse> ChangePublicUserInfoForCurrentUser(UpdatePublicUserInfoInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    
    [ForAnyAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of current user")]
    public async Task<DefaultActionResponse> AddUnpassingForCurrentUser(AddUnpassingInputObject unpassing)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }


    [ForAnyAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of current user")]
    public async Task<DefaultActionResponse> UpdateUnpassingForCurrentUser(UpdateUnpassingForCurrentUserInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [ForCorrectorAuthorize]
    [GraphQLName("AddUnpassing")]
    [GraphQLDescription("Add unpassing of any user (avaliable for admin and currector)")]
    public async Task<DefaultActionResponse> AddUnpassing(AddUnpassingInputObject unpassing)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }
    
    [ForCorrectorAuthorize]
    [GraphQLName("UpdateUnpassing")]
    [GraphQLDescription("Update unpassing of any user (avaliable for admin and currector)")]
    public async Task<DefaultActionResponse> UpdateUnpassing(UpdateUnpassingFromCurrectorInputObject update)
    {
        return DefaultActionResponse.FromResult(Result.Sucsesfull());
    }

    [AllowAnonymous]
    [GraphQLName("GenerateToken")]
    [GraphQLDescription("Generate auth token")]
    public async Task<DefaultActionResponse> Auth(AuthInputObject authData)
    {
        var authInfo = new AuntificateInfo(authData.Login, authData.Password);
        var AuthResult = await _authService.Authification(authInfo);

        if (AuthResult.IsSucsesfull)
        {
            var tokens = AuthResult.ResultValue;

            _acsessor.HttpContext.Response.Headers["Token"] = tokens.AuthToken;
            _acsessor.HttpContext.Response.Cookies.Append("Refresh", tokens.RefreshToken, new CookieOptions() { HttpOnly = true });
        }

        return DefaultActionResponse.FromResult(AuthResult);

    }

    //mutation Test
    //{
    //    GenerateToken(authData: { login: "123", password: "123" })
    //    {
    //        statusCode
    //        info
    //    }
    //}


}
