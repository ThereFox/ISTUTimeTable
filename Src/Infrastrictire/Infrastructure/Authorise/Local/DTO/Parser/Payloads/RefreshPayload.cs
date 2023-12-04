using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Authorise.JWT.DTO;
using Src.Core.Common;

namespace Authorise.JWT;

public class RefreshPayload : PayloadBase
{
    [JsonPropertyName("nbf")]
    public NumericDate NotActiveBefore { get; init; }

    public RefreshPayload(
        string issue,
        NumericDate issuedAt,
        NumericDate explanetion,
        NumericDate notActiveBefore
        )
    {
        Issue = issue;
        Explanetion = explanetion;
        IssuedAt = issuedAt;
        NotActiveBefore = notActiveBefore;
    }
}
