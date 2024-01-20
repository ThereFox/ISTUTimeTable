using ISTUTimeTable.Src.Core;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly UsersDBContext _databaseContext;

    public async Task<Result> AddRefreshToken(TokenUserInfo user, AuthBearer bearer)
    {
        throw new NotImplementedException();
        //_databaseContext.Bearers.AddAsync(new RefreshableBearerRecord());
    }

    public async Task<Result> ContainRefreshToken(string refreshBearer)
    {
         var recordWithRefreshToken = _databaseContext.Bearers.Where(ex => ex.RefreshToken == refreshBearer);

        if(recordWithRefreshToken.Count() == 0)
        {
            return Result.Failure(new Error("123", "Dont have inputed token"));
        }
        if(recordWithRefreshToken.First().LiveBefore < DateTime.Now)
        {
            return Result.Failure(new Error("123", "Refresh token dead"));    
        }
        return Result.Sucsesfull();
    }

    public Task<Result<TokenUserInfo>> GetUserInfoByRefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateUserCurrentRefreshToken(string oldToken, string newToken)
    {
        throw new NotImplementedException();
    }

    // public async Task<Result> UpdateUserCurrentRefreshToken(User user, string oldToken, string newToken)
    // {
    //     var oldTokenRecords = _databaseContext.Bearers
    //     .Where(ex => ex.UserId == user.Id && ex.RefreshToken == oldToken);

    //     if(await oldTokenRecords.AnyAsync() == false)
    //     {
    //         return Result.Failure(new Error("123", "dont have this token"));
    //     }

    //     _databaseContext.Bearers.Remove(await oldTokenRecords.FirstAsync());

    //     _databaseContext.Bearers.AddAsync(
    //         new RefreshableBearerRecord(

    //         )
    //     );

    // }


}
