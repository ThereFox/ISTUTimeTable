namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class UserInfo
{
    public int Id{get;set;}
    [GraphQLNonNullType]
    public string FullName{get;set;}
    [GraphQLNonNullType]
    public string Group {get;set;}
    public bool IsStudent {get;set;}
}
