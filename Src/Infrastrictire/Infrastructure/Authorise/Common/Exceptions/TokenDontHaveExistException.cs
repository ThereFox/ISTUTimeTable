using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorise.Common.Exceptions;

public class TokenDontHaveExistException : Exception
{
   public override string Message {get => "Token DontHaveExist";}
}
