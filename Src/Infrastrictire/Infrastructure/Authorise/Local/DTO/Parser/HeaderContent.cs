using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Authorise.JWT.DTO;

public class HeaderContent
{
    [JsonPropertyName("typ")]
    public string Type { get; init; }
    [JsonPropertyName("alg")]
    public string Algorithm { get; init; }

    public HeaderContent(string type, string algorithm) 
    {
        Type = type;
        Algorithm = algorithm;
    }
}
