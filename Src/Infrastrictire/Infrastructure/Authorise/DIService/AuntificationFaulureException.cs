using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorise.DIService;

public class AuntificationFaulureException : Exception
{
    public override string Message {get => "Dont have auntification info";}
}
