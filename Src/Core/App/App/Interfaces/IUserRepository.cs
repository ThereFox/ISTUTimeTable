using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace App.Interfaces;

public interface IUserAndGroupRepository
{
    public User GetUser(int id);
    public Group GetGroup(int id);
    
}
