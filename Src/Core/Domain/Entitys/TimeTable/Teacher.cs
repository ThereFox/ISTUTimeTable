namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class Teacher
{
    public int Id;
    public FullName Name;

    public List<Lesson> Lessons {get;set;}
}
