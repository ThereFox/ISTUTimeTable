using ApiTests.Helpfull;
using Microsoft.AspNetCore.Authentication;

namespace ApiTests.HelpfullEntitys.AuthMock;

public class TestAuthOption : AuthenticationSchemeOptions
{
    public const string Name = "TestWithConcreteRole";

}
