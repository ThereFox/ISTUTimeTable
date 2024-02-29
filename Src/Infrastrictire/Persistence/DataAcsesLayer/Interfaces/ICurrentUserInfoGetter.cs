using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.Common;

namespace ISTUTimeTable.Src.Core.App.Interfaces;

public interface ICurrentUserInfo
{
    public Task<Result<User>> Get();
     
}
