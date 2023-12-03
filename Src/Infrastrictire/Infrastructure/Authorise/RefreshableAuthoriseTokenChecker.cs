using App.Interfaces;
using App.token;
using Authorise.JWT;
using Authorise.JWT.DTO;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;

namespace Authorise;
public class RefreshableAuthoriseTokenChecker : IAuthorisationTokenChecker
{
    private readonly JWTTokenSource _tokenSource;

    private readonly IRefreshTokenRepository _refreshTokens;

    public async Task<Result<AuthBearer>> GenerateToken(TokenInfo info)
    {
        var token = _tokenSource.Generate(info);

        var saveTokenResult = await _refreshTokens.AddRefreshToken(info.userInfo, token);

        if(saveTokenResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(new Error("1", "Connot save token"));
        }

        return Result.Sucsesfull<AuthBearer>(token);
    }

    public Result<TokenUserInfo> GetUserInfoFromToken(string authToken)
    {
        var tokenParseResult = JWTToken<AuthPayload>.ReadFromString(authToken);

        if(tokenParseResult.IsSucsesfull == false)
        {
            return Result.Failure<TokenUserInfo>(tokenParseResult.ErrorInfo);
        }
        var tokenInfo = tokenParseResult.ResultValue;

        if(TokenIsExplained(tokenInfo))
        {
            return Result.Failure<TokenUserInfo>(new Error("4", "TokenExplained"));
        }
        return Result.Sucsesfull<TokenUserInfo>(new TokenUserInfo(tokenInfo.Payload.UserId, (Role)tokenInfo.Payload.UserRoleId));
    }

    public async Task<Result<AuthBearer>> RefreshToken(string RefreshToken)
    {
        var ContainRefreshTokenResult = await _refreshTokens.ContainRefreshToken(RefreshToken);

        if(ContainRefreshTokenResult.IsSucsesfull == false)
        {
            Result.Failure<AuthBearer>(ContainRefreshTokenResult.ErrorInfo);
        }

        var tokenInfo = await _refreshTokens.GetTokenOwnerInfo(RefreshToken);

        if(tokenInfo.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(tokenInfo.ErrorInfo);
        }

        var generatedToken = _tokenSource.Generate(tokenInfo.ResultValue);

        await _refreshTokens.RefreshToken(RefreshToken, generatedToken.RefreshToken);
        
        return Result.Sucsesfull<AuthBearer>(generatedToken);
    }

    private bool TokenIsExplained(JWTToken<AuthPayload> token)
    {
        return true;
    }
}
