using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using Authorise.JWT;
using ISTUTImeTable.Common;
using ISTUTImeTable.DataAcsesLayer;

namespace DataAcsesLayer.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly UsersDBContext _databaseContext;

    public async Task<Result> AddRefreshToken(TokenUserInfo user, AuthBearer bearer)
    {
        _databaseContext.Bearers.AddAsync(new RefreshableBearerRecord())
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

    public async Task<Result> UpdateUserCurrentRefreshToken(string oldToken, string newToken)
    {
        throw new NotImplementedException();
    }


}
