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
    public long NotActiveBefore { get; init; } // numericDate
    [JsonPropertyName("ref")]
    public long RefreshTimeout {get;init;}

}
