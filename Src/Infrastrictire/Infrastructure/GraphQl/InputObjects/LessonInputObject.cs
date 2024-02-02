using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class LessonInputObject
{
    [GraphQLNonNullType]
    public int SubjectId {get;set;}
    [GraphQLNonNullType]
    public int TeacherId {get;set;}
    [GraphQLNonNullType]
    public LessonType lessonType {get;set;}
    [GraphQLNonNullType]
    public int LocationId {get;set;}
    
    
}
