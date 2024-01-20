namespace ISTUTimeTable.Src.Core.App.DTO;

public class AuntificateInfo
{
    public string Login {get;init;}
    public string Password {get;init;}

    public AuntificateInfo(string login, string password)
    {
        Login = login;
        Password = password;
    }
}
