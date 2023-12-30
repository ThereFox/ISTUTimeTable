using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.token;
using Auth.Common;
using ISTUTImeTable.Common;

namespace Authorise;

public interface ITokenCreater
{
    public Result<PayloadType> ReadFromString<PayloadType>(string input);
    public AuthBearer Generate(TokenInfo tokenInfo);
}
