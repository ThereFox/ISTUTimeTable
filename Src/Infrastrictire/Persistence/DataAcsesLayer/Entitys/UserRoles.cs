using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class UserRoles
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool CanCorrectOwnGroup { get; private set; }
    public bool CanCorrectAnoutherGroup { get; private set; }

    public List<User> Users { get; private set; }
}
