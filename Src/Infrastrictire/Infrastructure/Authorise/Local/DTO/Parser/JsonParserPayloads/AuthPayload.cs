using System.Text.Json.Serialization;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class AuthPayload : PayloadBase
{
    [JsonPropertyName("id")]
    public int UserId { get; init; }
    [JsonPropertyName("rl")]
    public int UserRoleId { get; init; }

}
