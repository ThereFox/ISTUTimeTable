using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces;

public interface IUserAndGroupRepository
{
    public User GetUser(int id);
    public Group GetGroup(int id);
    
}
