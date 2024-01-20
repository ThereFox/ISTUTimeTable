namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class Lesson
{
    public TimeTableOnDay DayTimeTable { get;set; }

    public long id;

    public int SubjectId;
    public Subject Subject;

    public int TeacherId;
    public Teacher Teacher;
    public LessonType LessonType;
    public List<Group> Groups;

    public int LocationId;
    public Location Location;
    public List<Unpassing> Unpassings {get; set;}

    
    public List<Comment> Comments {get; set;}

}