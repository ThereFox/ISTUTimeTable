using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.App.DTO;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

namespace Authorise.Local.Interfaces;

public interface IAuthService
{
    public Task<Result<AuthBearer>> Authification(AuntificateInfo authenticateInfo);
    public Task<Result<TokenUserInfo>> GetAuthUserInfoFromToken(AuthBearer bearer);
    public Task<Result<AuthBearer>> ReAuthification(AuthBearer bearer);
}
