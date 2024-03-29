using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces;

public interface IUsersRepository
{
    public Task<Result> Add(User user);
    public Task<Result> RemoveById(int Id);
    public Task<Result<User>> GetById(int Id);
    public Task<Result> Update(int Id, User user);
    
}
