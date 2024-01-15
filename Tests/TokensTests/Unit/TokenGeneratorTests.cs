using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using Authorise.JWT;
using Authorise.JWT.DTO;
using ISTUTImeTable.Common;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests;

public class TokenGeneratorTests
{
    private readonly JWTTokenSource  _sut;

    public TokenGeneratorTests()
    {
        var configMock = new Mock<IOptions<AuthSecrets>>();
        configMock
        .Setup(ex => ex.Value)
        .Returns(new AuthSecrets("123", "123", "123"));
        _sut = new(
            configMock.Object
        );
    }

    [Fact]
    public void XUnitCorrectWork()
    {
        Assert.True(true);
    }

    [Fact]
    public void TokenGenerating()
    {
        var settings = new TokenInfo(
            new TokenUserInfo(1, ISTUTimeTable.Entitys.Role.Student),
            15,
            30
        );

        var generateTokenResult = _sut.Generate(settings);


        Assert.True(
            String.IsNullOrWhiteSpace(generateTokenResult.AuthToken) == false
            &&
            String.IsNullOrWhiteSpace(generateTokenResult.RefreshToken) == false
        );
    }

    [Fact]
    public void CanReadGeneratedToken()
    {
        var settings = new TokenInfo(
            new TokenUserInfo(1, ISTUTimeTable.Entitys.Role.Student),
            15,
            30
        );

        var generateTokenResult = _sut.Generate(settings);
        var tokenInfo = _sut.ReadFromString<AuthPayload>(generateTokenResult.AuthToken);

        Assert.True(
            tokenInfo.IsSucsesfull
            &&
            tokenInfo.ResultValue.UserId == settings.UserInfo.UserId
            &&
            tokenInfo.ResultValue.UserRoleId == (int)settings.UserInfo.UserRole
        );
    }

}
