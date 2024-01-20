using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using ISTUTimeTable.Src.Core.App.DTO;


namespace ISTUTImeTable.Authorise.Logic;

public class AuthService
{
    private IAuntificator _auntificator;
    private IAuthorisationTokenChecker _tokenChecker;

public AuthService(IAuntificator auntificator, IAuthorisationTokenChecker tokenChecker)
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

    public async Task<Result> Authorise(AuthBearer bearer)
    {
        await Task.CompletedTask;
        
        var tokenInfo = _tokenChecker.GetUserInfoFromToken(bearer.AuthToken);

        if(tokenInfo.IsSucsesfull)
        {
            return Result.Sucsesfull();
        }
        return Result.Failure(tokenInfo.ErrorInfo);

    }

}
