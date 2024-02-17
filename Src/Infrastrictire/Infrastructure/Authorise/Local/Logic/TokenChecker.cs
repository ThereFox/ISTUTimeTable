using Authorise.Interfaces;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Core.Domain.Entitys;


namespace Authorise.Logic;
public class JWTTokenWorker : IAuthorisationTokenWorker
{
    private readonly ITokenCreater _tokenSource;
    private readonly IRefreshTokenRepository _refreshTokens;

    public JWTTokenWorker(ITokenCreater tokenCreater, IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenSource = tokenCreater;
        _refreshTokens = refreshTokenRepository;
    }


    public async Task<Result<AuthBearer>> GenerateTokenAsync(TokenInfo info)
    {
        var token = _tokenSource.Generate(info);

        // var saveTokenResult = await _refreshTokens.AddRefreshToken(info.UserInfo, token);

        // if(saveTokenResult.IsSucsesfull == false)
        // {
        //     return Result.Failure<AuthBearer>(new Error("1", "Connot save token"));
        // }

        return Result.Sucsesfull<AuthBearer>(token);
    }

    public Result<TokenUserInfo> GetUserInfoFromToken(string authToken)
    {
        var tokenParseResult = _tokenSource.ReadFromString<AuthPayload>(authToken);

        if(tokenParseResult.IsSucsesfull == false)
        {
            return Result.Failure<TokenUserInfo>(tokenParseResult.ErrorInfo);
        }
        var tokenInfo = tokenParseResult.ResultValue;

        if(TokenIsExplained(tokenInfo))
        {
            return Result.Failure<TokenUserInfo>(new Error("4", "TokenExplained"));
        }
        return Result.Sucsesfull<TokenUserInfo>(new TokenUserInfo(tokenInfo.UserId, (Role)tokenInfo.UserRoleId));
    }

    public async Task<Result<AuthBearer>> RefreshTokenAsync(string RefreshToken)
    {
        var ContainRefreshTokenResult = await _refreshTokens.ContainRefreshToken(RefreshToken);

        if(ContainRefreshTokenResult.IsSucsesfull == false)
        {
            Result.Failure<AuthBearer>(ContainRefreshTokenResult.ErrorInfo);
        }

        var tokenInfo = await _refreshTokens.GetUserInfoByRefreshToken(RefreshToken);

        if(tokenInfo.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(tokenInfo.ErrorInfo);
        }

        var generatedToken = _tokenSource.Generate(
            new TokenInfo(tokenInfo.ResultValue, 10, 30)
        );

        var updateTokenResult = await _refreshTokens.UpdateUserCurrentRefreshToken(RefreshToken, generatedToken.RefreshToken);
        
        if(updateTokenResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(updateTokenResult.ErrorInfo);
        }

        return Result.Sucsesfull<AuthBearer>(generatedToken);
    }

    private bool TokenIsExplained(AuthPayload token)
    {
        return (DateTime)new NumericDate(token.Explanetion) > DateTime.Now;
    }
}
