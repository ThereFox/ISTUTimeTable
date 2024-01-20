namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class Comment
{
    public int Id;
    public DateOnly Date;

    public int WriterId {get;set;}
    public User Writer;

    public int LessonId {get;set;}
    public Lesson ForLesson;

    public string Message;
    public CommentType commentType;
}