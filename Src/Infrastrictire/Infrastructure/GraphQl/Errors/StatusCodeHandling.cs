using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;

namespace GraphQl.Errors;

public class StatusCodeHandling : DefaultHttpResponseFormatter
{
    protected override HttpStatusCode OnDetermineStatusCode(IQueryResult result, FormatInfo format, HttpStatusCode? proposedStatusCode)
    {
        if(result.Errors.Any() || proposedStatusCode.HasValue && proposedStatusCode.Value == HttpStatusCode.NotFound)
        {
            return HttpStatusCode.BadRequest;
        }
        
        if(proposedStatusCode is null)
        {
            return HttpStatusCode.OK;
        }

        return base.OnDetermineStatusCode(result, format, proposedStatusCode);
    }
}
