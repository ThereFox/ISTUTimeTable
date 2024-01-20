using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.Domain.Exceptions;

public class CommentCreatedByEnoutherUserException : Exception
{
    public CommentCreatedByEnoutherUserException(Comment comment)
    : base
    (
        $"Comment with ${comment.Id} ID created by anouther user (by ${comment.Writer.Name.FirstName} ${comment.Writer.Name.LastName})"
    )
    {
        
    }
}
