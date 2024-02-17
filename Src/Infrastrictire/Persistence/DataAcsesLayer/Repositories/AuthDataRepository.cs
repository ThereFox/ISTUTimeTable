using Authorise.Local.Interfaces;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthDataRepository : IAuthDataRepository
    {
        private readonly UsersDBContext _databaseContext;

        public AuthDataRepository(UsersDBContext context)
        {
            _databaseContext = context;
        }

        public bool ContaintUser(string login)
        {
            return true;
        }

        public Result<User> GetUserByLoginAndPassword(string login, string password)
        {
            return Result.Sucsesfull<User>(_databaseContext.Users.First() ?? default);
        }
    }
}
