using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;

public class RefreshableBearerRecord
{
    public int Id {get;init;}
    public int UserId {get;set;}
    public User user {get;set;}
    public string RefreshToken { get; init; }
    public DateTime LiveBefore {get;init;}
}
