using System;
using System.Collections.Generic;
using System.Linq;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;

public interface IAuthorisationTokenWorker
{
    public Task<Result<AuthBearer>> GenerateTokenAsync(TokenInfo info);
    public Task<Result<AuthBearer>> RefreshTokenAsync(string RefreshToken);
    public Result<TokenUserInfo> GetUserInfoFromToken(string authToken);
}
