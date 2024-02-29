using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class LessonInputObject
{
    [GraphQLNonNullType]
    public int SubjectId {get;}
    [GraphQLNonNullType]
    public int TeacherId {get;}
    [GraphQLNonNullType]
    public LessonType LessonType {get;}
    [GraphQLNonNullType]
    public int LocationId {get;}

    public LessonInputObject(int subjectId, int teacherId, LessonType lessonType, int locationId)
    {
        SubjectId = subjectId;
        TeacherId = teacherId;
        LessonType = lessonType;
        LocationId = locationId;

    }

}
