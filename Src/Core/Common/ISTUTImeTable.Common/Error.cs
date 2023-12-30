using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTImeTable.Common;

public sealed class Error
{
    public string Code { get; init; }
    public string Message { get; init; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new Error("-","None");
}
