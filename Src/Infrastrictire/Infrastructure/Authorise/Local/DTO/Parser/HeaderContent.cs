using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Authorise.JWT.DTO;

public class HeaderContent
{
    [JsonPropertyName("alg")]
    [JsonInclude]
    public string Algorithm { get; set; }
    [JsonPropertyName("typ")]
    [JsonInclude]
    public string Type { get; set; }

    [JsonConstructor]
    public HeaderContent(string alg, string typ) 
    {
        Algorithm = alg;
        Type = typ;
    }
}
