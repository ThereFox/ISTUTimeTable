using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;


namespace Authorise.Interfaces;

public interface ITokenCreater
{
    public Result<PayloadType> ReadFromString<PayloadType>(string input);
    public AuthBearer Generate(TokenInfo tokenInfo);
}
