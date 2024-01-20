using ISTUTimeTable.Src.Core.App.DTO;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;

public interface IAuntificator
{
    public Result<User> Auntificate(AuntificateInfo auntificateInfo);
}
