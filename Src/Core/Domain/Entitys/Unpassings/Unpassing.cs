namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class Unpassing
{
    public int Id { get; set; }
    public DateOnly InformingDate { get; set; }
    
    public int TimeTableOnDayId { get; private set; }
    public TimeTableOnDay Day { get; set; }
    
    public int StudentId { get; private set; }
    public User Student { get;set; }

    public int LessonId { get; private set; }
    public Lesson lesson { get; set; }
    public UnpassingReason Reason { get; set;}
}
