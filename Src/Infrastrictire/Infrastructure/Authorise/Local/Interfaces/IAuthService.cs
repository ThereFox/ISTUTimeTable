using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.App.DTO;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;

namespace Authorise.Local.Interfaces;

public interface IAuthService
{
    public Task<Result<AuthBearer>> Authification(AuntificateInfo authenticateInfo);
    public Task<Result> IsAuthUser(AuthBearer bearer);
    public Task<Result<AuthBearer>> ReAuthification(AuthBearer bearer);
}
