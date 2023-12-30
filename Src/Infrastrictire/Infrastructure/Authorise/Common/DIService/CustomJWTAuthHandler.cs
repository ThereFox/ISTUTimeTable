using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorise.DIService;
using Microsoft.AspNetCore.Authentication;
using ISTUTImeTable.Common;
using App.token;
using App.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Auth.Common;

namespace Authorise;

public class CustomJWTAuthHandler : AuthenticationHandler<CustomJWTAuthSchemeOption>
{
    private const string HeaderAuthTokenName = "AuthToken";
    private const string CookieRefreshTokenName = "RefreshToken";

    private readonly IAuthorisationTokenChecker _tokenChecker;

    public CustomJWTAuthHandler(IOptionsMonitor<CustomJWTAuthSchemeOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) 
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authTokenResult = getAuthTokenFromRequest();

        if(authTokenResult.IsSucsesfull)
        {
            var getUserInfoResult = getUserInfoFromAuthToken(authTokenResult.ResultValue);

            if(getUserInfoResult.IsSucsesfull)
            {
                return auntificateByUserInfo(getUserInfoResult.ResultValue);
            }

        }

        var refreshTokenResult = getRefreshTokenFromRequest();

        if(refreshTokenResult.IsSucsesfull == false)
        {
            return DontHaveAuntification();
        }
        
        var newTokensResult = await RefreshToken(refreshTokenResult.ResultValue);

        if(newTokensResult.IsSucsesfull == false)
        {
            return DontHaveAuntification();
        }

        setTokensForUser(newTokensResult.ResultValue);
        
        var userInfoResult = getUserInfoFromAuthToken(newTokensResult.ResultValue.AuthToken);

        if(userInfoResult.IsSucsesfull)
        {
            return auntificateByUserInfo(userInfoResult.ResultValue);
        }
        else
        {
            throw new ApplicationException("generator token failure");
        }

    }

    private AuthenticateResult DontHaveAuntification()
    {
        return AuthenticateResult.Fail(new AuntificationFaulureException());
    }

    private Result<string> getAuthTokenFromRequest()
    {
        var authToken = this.Request.Headers.Where(ex => ex.Key == HeaderAuthTokenName).FirstOrDefault(null);

        if(authToken.Equals(null))
        {
            return Result.Failure<string>(new Error("123", "dontHaveToken"));
        }
        if(String.IsNullOrWhiteSpace(authToken.Value))
        {
            return Result.Failure<string>(new Error("123", "dontHaveToken"));
        }

        return Result.Sucsesfull<string>(authToken.Value);
    }
    private Result<string> getRefreshTokenFromRequest()
    {
        var token = this.Request.Cookies.Where(ex => ex.Key == CookieRefreshTokenName).FirstOrDefault(null);

        if(token.Equals(null))
        {
            return Result.Failure<string>(new Error("123", "DontHaveToken"));
        }
        if(String.IsNullOrWhiteSpace(token.Value))
        {
            return Result.Failure<string>(new Error("123", "empty token"));
        }



        return Result.Sucsesfull<string>(token.Value);
    }
    private AuthenticateResult auntificateByUserInfo(TokenUserInfo userInfo)
    {
        var userIdClaim = new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString());
        var userRoleClaim = new Claim(ClaimTypes.Role, userInfo.UserRole.ToString());

        var claimIdentity = new ClaimsIdentity(new List<Claim> { userIdClaim, userRoleClaim});
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            return AuthenticateResult.Success(
                new AuthenticationTicket(
                    claimPrincipal,
                    this.Scheme.Name
                )
            );
    }

    private Result<TokenUserInfo> getUserInfoFromAuthToken(string token)
    {
        var userInfoResult = _tokenChecker.GetUserInfoFromToken(token);

        if(userInfoResult.IsSucsesfull == false)
        {
            return Result.Failure<TokenUserInfo>(userInfoResult.ErrorInfo);
        }
        return Result.Sucsesfull<TokenUserInfo>(userInfoResult.ResultValue);
    }

    private async Task<Result<AuthBearer>> RefreshToken(string refreshToken)
    {
        var newTokensResult = await _tokenChecker.RefreshTokenAsync(refreshToken);
        if(newTokensResult.IsSucsesfull)
        {
            return Result.Sucsesfull<AuthBearer>(newTokensResult.ResultValue);
        }
        return Result.Failure<AuthBearer>(newTokensResult.ErrorInfo);
    }
    private void setTokensForUser(AuthBearer bearer)
    {
        this.Response.Headers.Append(
            HeaderAuthTokenName,
            bearer.AuthToken
        );

        this.Response.Cookies.Append(
            CookieRefreshTokenName,
            bearer.RefreshToken,
            new CookieOptions()
            {
                Secure = true,
                HttpOnly = true
            }
        );

    }

}
