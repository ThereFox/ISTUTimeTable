using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateCommentInputObject
{
    //need add anyOf

    [GraphQLNonNullType]
    public int CommentId {get;}
    public string NewMessage {get;}
    public CommentType CommentType { get; }

    public UpdateCommentInputObject(int commentId, string newMessage, CommentType commentType)
    {
        CommentId = commentId;
        NewMessage = newMessage;
        CommentType = commentType;
    }
}
