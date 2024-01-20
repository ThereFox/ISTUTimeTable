namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class TimeTableOnDay
{
    public int Id {get;set;}
    public DateOnly Date {get;set;}
    
    public TimeTableOnWeek TimeTable {get;set;}

    public int FirstLessonId {get;set;}
    public Lesson FirstLesson {get;set;}

    public int SecondLessonId {get;set;}
    public Lesson SecondLesson {get;set;}

    public int ThrigthLessonId {get;set;}
    public Lesson ThrigthLesson {get;set;}

    public int FourthLessonId {get;set;}
    public Lesson FourthLesson {get;set;}

    public int FivethLessonId {get;set;}
    public Lesson FivethLesson {get;set;}
}