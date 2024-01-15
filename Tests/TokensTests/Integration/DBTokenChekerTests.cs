using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorise;
using Authorise.JWT;
using ISTUTImeTable.Common;
using Microsoft.Extensions.Options;
using Moq;

namespace IntergationTests;

public class TokenChekerTests
{
    private JWTTokenWorker _sut;

    public TokenChekerTests()
    {
        var defaultUserInfo = new AuthSecrets("123", "123", "123");

        var configMock = new Mock<IOptions<AuthSecrets>>();
        configMock
        .Setup(ex => ex.Value)
        .Returns(defaultUserInfo);
        
        var savingMock = new Mock<IRefreshTokenRepository>();
        _sut = new(
            new JWTTokenSource(configMock.Object),
            savingMock.Object
        );
    }



}
