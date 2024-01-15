using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Errors;

public class SimpleCustomErrorFiltr : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.WithMessage(error.Exception.Message);
    }
}
