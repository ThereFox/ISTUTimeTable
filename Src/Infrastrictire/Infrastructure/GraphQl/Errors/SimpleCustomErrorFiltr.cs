namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Errors;

public class SimpleCustomErrorFiltr : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.WithMessage(error.Exception.Message);
    }
}
