namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;

public class AuthBearer
{
    public string AuthToken {get;set;}
    public string RefreshToken {get;set;}
    public AuthBearer(string auth, string refresh)
    {
        AuthToken = auth;
        RefreshToken = refresh;
    }
}
