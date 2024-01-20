using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class PublicUserInfo
{
    public FullName Name;
    public string publicIndentificator;
    public Group GroupInfo;
}
