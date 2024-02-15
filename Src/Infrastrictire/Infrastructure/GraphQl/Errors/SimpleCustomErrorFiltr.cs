namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Errors;

public class SimpleCustomErrorFiltr : IErrorFilter
{
    public IError OnError(IError error)
    {
        if(error.Exception == null)
        {
            return error.RemoveException();
        }

        return error.WithMessage(error.Exception.Message);
    }
}
