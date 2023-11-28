using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace App.token;

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
