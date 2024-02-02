using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces;

public interface ICurrentUserInfo
{
    public Task<Result<User>> Get();
     
}
