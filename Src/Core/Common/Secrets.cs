namespace ISTUTimeTable.Src.Core.Common;

public class AuthSecrets
{
    public string Issuer { get; init; }
    public string JWTSecrets { get; init; }
    public string EncriptingKey { get; init; }
}