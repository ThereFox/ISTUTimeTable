using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class AuthTokens
{
    public int Id { get; private set; }
    public int OwnerId { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime LiveBefore { get; private set; } 

    public User Owner { get; private set; }

}
