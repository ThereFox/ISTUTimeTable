using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using ISTUTimeTable.Src.Core.App.DTO;
using Authorise.Local.Interfaces;
using ISTUTimeTable.Src.Core.Domain.Entitys;


namespace ISTUTImeTable.Authorise.Logic;

public class AuthService : IAuthService
{
    private IAuntificator _auntificator;
    private IAuthorisationTokenWorker _tokenChecker;

    public AuthService(IAuntificator auntificator, IAuthorisationTokenWorker tokenChecker)
    {
        _auntificator = auntificator;
        _tokenChecker = tokenChecker;
    }

    public async Task<Result<AuthBearer>> Authification(AuntificateInfo authenticateInfo)
    {
        var auntificateResult = _auntificator.Auntificate(authenticateInfo);
        
        if(auntificateResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(auntificateResult.ErrorInfo);
        }
        var userInfo = auntificateResult.ResultValue;
        var tokenInfo = new TokenInfo(new TokenUserInfo(userInfo.Id, userInfo.Role), 15, 30);

        var tokenGenerateResult = await _tokenChecker.GenerateTokenAsync(tokenInfo);

        if(tokenGenerateResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(tokenGenerateResult.ErrorInfo);
        }

        return Result.Sucsesfull<AuthBearer>(tokenGenerateResult.ResultValue);
    }

    public async Task<Result<TokenUserInfo>> GetAuthUserInfoFromToken(AuthBearer bearer)
    {
        await Task.CompletedTask;
        
        var tokenInfo = _tokenChecker.GetUserInfoFromToken(bearer.AuthToken);

        if(tokenInfo.IsSucsesfull)
        {
            return Result.Sucsesfull<TokenUserInfo>(tokenInfo.ResultValue);
        }
        return Result.Failure<TokenUserInfo>(tokenInfo.ErrorInfo);

    }

    public async Task<Result<AuthBearer>> ReAuthification(AuthBearer bearer)
    {
        var newBearer = await _tokenChecker.RefreshTokenAsync(bearer.RefreshToken);
    
        if(newBearer.IsSucsesfull == false)
        {
            return Result.Failure<AuthBearer>(newBearer.ErrorInfo);
        }
        return newBearer;
    }
}
