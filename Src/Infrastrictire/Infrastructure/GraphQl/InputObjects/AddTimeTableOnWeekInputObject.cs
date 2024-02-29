using GraphQl.InputObjects;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddTimeTableOnWeekInputObject
{

    [GraphQLNonNullType]
    public int GroupId {get;}
    [GraphQLNonNullType]
    public DateOnly MondayDate {get;}

    [GraphQLNonNullType]
    public TimeTableOnDayRecord Monday {get;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Tuesday{get;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Wednesday{get;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Thursday{get;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Friday{get;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Saturday{get;}

    public AddTimeTableOnWeekInputObject(
        int groupId,
        DateOnly mondayDate,
        TimeTableOnDayRecord monday,
        TimeTableOnDayRecord tuesday,
        TimeTableOnDayRecord wednesday,
        TimeTableOnDayRecord thursday,
        TimeTableOnDayRecord friday,
        TimeTableOnDayRecord saturday
        )
    {
        GroupId = groupId;
        MondayDate = mondayDate;
        Monday = monday;
        Tuesday = tuesday;
        Wednesday = wednesday;
        Thursday = thursday;
        Friday = friday;
        Saturday = saturday;

    }
}
