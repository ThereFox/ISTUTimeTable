using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using ISTUTImeTable.Common;

namespace Authorise.JWT;

public interface IRefreshTokenRepository
{
    public Task<Result> AddRefreshToken(AuthBearer bearer);
    public Task<Result> ContainRefreshToken(string refreshBearer);
    public Task<Result<TokenInfo>> GetTokenOwnerInfo(string token);
    public Task<Result> RefreshToken(string oldToken, string newToken);
}
