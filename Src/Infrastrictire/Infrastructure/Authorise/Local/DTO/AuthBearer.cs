using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Common;

public class AuthBearer
{
    public string AuthToken;
    public string RefreshToken;
    public AuthBearer(string auth, string refresh)
    {
        AuthToken = auth;
        RefreshToken = refresh;
    }
}
