using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.App.DTO;
using ISTUTimeTable.Src.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorise.Local.Interfaces
{
    public interface IAuthDataRepository
    {
        public bool ContaintUser(string login);
        public Result<User> GetUserByLoginAndPassword(string login, string password);
    }
}
