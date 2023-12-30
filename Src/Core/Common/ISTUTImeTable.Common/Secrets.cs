using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTImeTable.Common;

public class AuthSecrets
{
    public string Issuer { get; init; }
    public string JWTSecrets { get; init; }
    public string EncriptingKey { get; init; }

    public AuthSecrets(string issuer, string secreys, string encriptingKey)
    {
        Issuer = issuer;
        JWTSecrets = secreys;
        EncriptingKey = encriptingKey;   
    }
}
