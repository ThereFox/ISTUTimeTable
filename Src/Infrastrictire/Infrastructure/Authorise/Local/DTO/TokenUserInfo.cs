
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class TokenUserInfo
{
    public int UserId {get; set;}
    public Role UserRole{get; set;}

    public TokenUserInfo(int id, Role role)
    {
        UserId = id;
        UserRole = role;
    }
}
