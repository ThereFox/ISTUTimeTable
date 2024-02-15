using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddCommentInputObject
{
    [GraphQLNonNullType]
    public int LessonId {get;}
    [GraphQLNonNullType]
    public string Message {get;}
    [GraphQLNonNullType]
    public CommentType CommentType {get;}

    public AddCommentInputObject(int lessonId, string message, CommentType commentType)
    {
        LessonId = lessonId;
        Message = message;
        CommentType = commentType;
    }

}
