using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;

public interface IRefreshTokenRepository
{
    public Task<Result> AddRefreshToken(TokenUserInfo user,  AuthBearer bearer);
    public Task<Result> ContainRefreshToken(string refreshBearer);
    public Task<Result<TokenUserInfo>> GetUserInfoByRefreshToken(string refreshToken);
    public Task<Result> UpdateUserCurrentRefreshToken(string oldToken, string newToken);
}
