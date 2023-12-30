using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using Auth.Common;
using Authorise.JWT;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;

namespace App.Interfaces;

public interface IAuthorisationTokenChecker
{
    public Task<Result<AuthBearer>> GenerateTokenAsync(TokenInfo info);
    public Task<Result<AuthBearer>> RefreshTokenAsync(string RefreshToken);
    public Result<TokenUserInfo> GetUserInfoFromToken(string authToken);
}
