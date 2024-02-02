using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateCommentInputObject
{
    [GraphQLNonNullType]
    public int CommentId {get;set;}
    public string newMessage {get;set;}
    public CommentType commentType;
}
