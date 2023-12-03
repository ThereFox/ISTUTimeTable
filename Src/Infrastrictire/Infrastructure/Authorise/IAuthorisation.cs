using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using Authorise.JWT;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;

namespace App.Interfaces;

public interface IAuthorisationTokenChecker
{
    public Task<Result<AuthBearer>> GenerateToken(TokenInfo info);
    public Task<Result<AuthBearer>> RefreshToken(string RefreshToken);
    public Result<TokenUserInfo> GetUserInfoFromToken(string authToken);
}
