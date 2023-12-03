using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace App.token;

public class TokenInfo
{
    public TokenUserInfo UserInfo {get; init;}

    public int MinutsOfLife {get; set;}
    public int MinutsForRefresh {get; set;}

    public TokenInfo(TokenUserInfo userInfo, int minutsOfLife, int minutsForRefresh) 
    {
        UserInfo = userInfo;
        MinutsOfLife = minutsOfLife;
        MinutsForRefresh = minutsForRefresh;
    }

}
