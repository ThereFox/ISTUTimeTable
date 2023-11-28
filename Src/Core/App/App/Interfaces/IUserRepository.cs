using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace App.Interfaces;

public interface IUserRepository
{
    public User GetUser(int id);
    
}
