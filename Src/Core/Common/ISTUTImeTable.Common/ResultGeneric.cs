using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTImeTable.Common;

public class Result<T> : Result
{
    private readonly T _result;
    public T ResultValue
    {
        get => IsSucsesfull ? _result : throw new InvalidCastException("Can't get result");
    }

    public Result(T result, bool isSucsesfull, Error error)
    : base(isSucsesfull, error)
    {
        _result = result;
    }


}
