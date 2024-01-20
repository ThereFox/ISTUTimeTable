using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using ISTUTimeTable.Src.Core.Domain.Exceptions;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Mutations;

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
        await Task.CompletedTask;

        //_notificationSender.SendAsync("");

    }
    
    [OnlyForAdminAuthorize]
    [GraphQLName("DropGroup")]
    [GraphQLDescription("Delete group (avaliable for admin)")]
    [Error(typeof(GroupAlreadyExistException))]
    public async Task DeleteGroup([ID] int id)
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
        await Task.CompletedTask;
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
    public async Task ChangeUserGroup([ID] int userID, [ID] int newUserGroup)
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

    [AllowAnonymous]
    [GraphQLName("GenerateToken")]
    [GraphQLDescription("Generate auth token")]
    public async Task<AuthBearer> Auth(string login, string password)
    {
        await Task.CompletedTask;
        return new AuthBearer("123", "123");
    }

    [AllowAnonymous]
    [GraphQLName("GenerateToken")]
    [GraphQLDescription("Generate auth token")]
    public async Task<AuthBearer> RefreshAuthToken(string refreshToken)
    {
        throw new NotImplementedException();
    }


}
