using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using App.token;
using Authorise.JWT.DTO;
using ISTUTimeTable.Entitys;
using Src.Core.Common;

namespace Authorise.JWT;

public class AuthPayload : PayloadBase
{
    [JsonPropertyName("id")]
    public int UserId { get; init; }
    [JsonPropertyName("rl")]
    public int UserRoleId { get; init; }

    public AuthPayload(TokenUserInfo user, string issue,NumericDate issuedAt, NumericDate explanetion)
    {
        UserId = user.UserId;
        UserRoleId = (int)user.UserRole;
        Issue = issue;
        IssuedAt = issuedAt;
        Explanetion = explanetion;
    }
}
