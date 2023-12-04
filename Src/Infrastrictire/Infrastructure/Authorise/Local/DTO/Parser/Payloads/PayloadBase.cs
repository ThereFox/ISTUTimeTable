using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Src.Core.Common;

namespace Authorise.JWT.DTO;

public class PayloadBase
{
    [JsonPropertyName("iss")]
    public string Issue {get; init; }
    [JsonPropertyName("exp")]
    public NumericDate Explanetion { get; init; }
    [JsonPropertyName("iat")]
    public NumericDate IssuedAt { get; init; }
}
