using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace Authorise.JWT;

public class RefreshableBearerRecord
{
    public int Id {get;init;}
    public int UserId {get;set;}
    public User user {get;set;}
    public string RefreshToken { get; init; }
    public DateTime LiveBefore {get;init;}
}
