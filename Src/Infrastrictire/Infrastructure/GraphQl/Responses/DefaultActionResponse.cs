using ISTUTimeTable.Src.Core.Common;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQl.Responses
{
    public class DefaultActionResponse
    {
        public string StatusCode { get; }
        public string Info { get; }

        public DefaultActionResponse(string code, string message)
        {
            StatusCode = code;
            Info = message;

        }

        public static DefaultActionResponse FromResult(Result result)
        {
            return new DefaultActionResponse(
                result.IsSucsesfull ? "0" : result.ErrorInfo.Code,
                result.ErrorInfo.Message
                );
        }
    }
}
