using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.InputObjects;

public class AuthInputObject
{
    [GraphQLNonNullType]
    public string Login {get;set;}
    [GraphQLNonNullType]
    public string Password {get;set;}

}
