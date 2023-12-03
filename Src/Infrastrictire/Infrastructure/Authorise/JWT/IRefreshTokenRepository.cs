using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;

namespace Authorise.JWT;

public interface IRefreshTokenRepository
{
    public Task<Result> AddRefreshToken(TokenUserInfo user,  AuthBearer bearer);
    public Task<Result> ContainRefreshToken(string refreshBearer);
    public Task<Result> UpdateUserCurrentRefreshToken(string oldToken, string newToken);
}
