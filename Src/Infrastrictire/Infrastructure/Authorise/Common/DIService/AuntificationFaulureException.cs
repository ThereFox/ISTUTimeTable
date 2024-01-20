namespace ISTUTimeTable.Src.Infrastructure.Authorise.DIService;

public class AuntificationFaulureException : Exception
{
    public override string Message {get => "Dont have auntification info";}
}
