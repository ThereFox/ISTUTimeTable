using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace Entitys.Exceprions;

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
