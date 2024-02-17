using ISTUTimeTable.Src.Core.App.DTO;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authorise.Local.Interfaces;

namespace Authorise.Local.Logic
{
    public class AuthDataChecker : IAuntificator
    {
        private readonly IAuthDataRepository _repository;

        public AuthDataChecker(
            IAuthDataRepository repository
            )
        {
            _repository = repository;
        }

        public Result<User> Auntificate(AuntificateInfo auntificateInfo)
        {
            if (_repository.ContaintUser(auntificateInfo.Login) == false)
            {
                return Result.Failure<User>(new Error("123", "Don't have user"));
            }

            var passwordHash = auntificateInfo.Password.GetHashCode().ToString();

            var getUserResult = _repository.GetUserByLoginAndPassword(auntificateInfo.Login, passwordHash);

            return getUserResult;
        }
    }
}
