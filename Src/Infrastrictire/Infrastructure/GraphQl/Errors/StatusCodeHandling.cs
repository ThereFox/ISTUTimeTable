using System.Net;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Errors;

public class StatusCodeHandling : DefaultHttpResponseFormatter
{
    protected override HttpStatusCode OnDetermineStatusCode(IQueryResult result, FormatInfo format, HttpStatusCode? proposedStatusCode)
    {
        if(result.Errors != null && result.Errors.Any() || proposedStatusCode.HasValue && proposedStatusCode.Value == HttpStatusCode.NotFound)
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
