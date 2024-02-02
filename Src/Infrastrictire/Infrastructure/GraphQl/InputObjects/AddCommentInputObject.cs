using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddCommentInputObject
{
    [GraphQLNonNullType]
    public int LessonId {get;set;}
    [GraphQLNonNullType]
    public string Message {get;set;}
    [GraphQLNonNullType]
    public CommentType commentType {get;set;}
}
