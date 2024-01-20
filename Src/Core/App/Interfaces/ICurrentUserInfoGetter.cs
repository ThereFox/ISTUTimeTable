using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces;

public interface ICurrentUserInfoGetter
{
    public Group GetGroupFromConcrectUser();
     
}
