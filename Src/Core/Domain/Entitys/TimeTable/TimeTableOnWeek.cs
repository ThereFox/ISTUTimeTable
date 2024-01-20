namespace ISTUTimeTable.Src.Core.Domain.Entitys;

public class TimeTableOnWeek
{
    public int id { get; set; }

    public int GroupId {get;set;}
    public Group Group { get; set; }


    public int MondayTimeTableId { get; set; }
    public TimeTableOnDay Monday { get; set; }

    public int TuesdayTimeTableId { get; set; }
    public TimeTableOnDay Tuesday { get; set; }

    public int WensdayTimeTableId { get; set; }
    public TimeTableOnDay Wensday { get; set; }

    public int ThusdayTimeTableId { get; set; }
    public TimeTableOnDay Thusday { get; set; }

    public int FridayTimeTableId { get; set; }
    public TimeTableOnDay Friday { get; set; }

}