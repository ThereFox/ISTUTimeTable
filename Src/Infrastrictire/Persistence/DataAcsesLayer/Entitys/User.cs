using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public int GroupId { get; private set; }
    public int RoleId { get; private set; }

    public Group Group { get; private set; }
    public UserRoles Role { get; private set; }

    public List<AuthTokens> Tokens { get; private set; }
    public List<Comments> Comments { get; private set; }
    public List<Unpassings> Unpassings { get; private set; }

}
