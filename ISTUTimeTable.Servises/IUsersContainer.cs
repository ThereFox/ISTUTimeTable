using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace ISTUTimeTable.Servises;

public interface IUsersContainer
{
    public bool HaveUserWithId(int id);
    public User GetUserById(int id);
}
