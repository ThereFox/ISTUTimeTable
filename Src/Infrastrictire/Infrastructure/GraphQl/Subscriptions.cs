using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;
using ISTUTimeTable.Src.Core.Domain.Entitys;


namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Subscription;

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

//SOLID
//S - Одна причина для изменений
//O - Принцип открытости закрытости - открыт для расширения закрыт для изменения
//L - Принцип подстановки барбары лисков - возможность замены класса 