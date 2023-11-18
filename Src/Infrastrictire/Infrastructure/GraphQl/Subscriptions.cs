using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Authorise.Attributes;
using HotChocolate;
using ISTUTimeTable.Entitys;

namespace GraphQl;

public class Subscriptions
{
    [ForAnyAuthorize]
    [Subscribe]
    [GraphQLName("OnTimeTableChange")]
    [GraphQLDescription("Subscribe for changing timetable on day")]
    public async Task<TimeTableOnDay> TimeTableOnDayChanged(
        [EventMessage] TimeTableOnDay day
    ) => day;

    [ForAnyAuthorize]
    [Subscribe]
    [GraphQLName("OnLessonChange")]
    [GraphQLDescription("Subscribe for changing lessons info")]
    public async Task<Lesson> OnLessonInfoChanged(
        DateOnly date,
        [EventMessage] Lesson lesson
    ) => lesson;

    [ForAnyAuthorize]
    [Subscribe]
    [GraphQLName("OnCommentAdd")]
    [GraphQLDescription("Subscribe for adding comments")]
    public async Task<Comment> OnCommentAdded(
        [ID]int lessonId,
        [EventMessage] Comment comment
    )
    {
        return comment;
    }

    [ForAnyAuthorize]
    [Subscribe]
    [GraphQLName("OnCommentChange")]
    [GraphQLDescription("Subscribe for changinh comment")]
    public async Task<Comment> OnCommentChanged(
        [ID]int lessonId,
        [EventMessage] Comment comment
    )
    {
        return comment;
    }

}
