using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;

namespace Authorise.Common.Exceptions;

public class TokensInvalidException : Exception
{
    public override string Message {get;}

    public TokensInvalidException(Error error)
    {
        Message = $"{error.Code} - {error.Message}";
    }

}
