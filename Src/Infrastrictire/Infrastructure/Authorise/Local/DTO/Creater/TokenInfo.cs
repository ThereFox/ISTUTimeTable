namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

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
