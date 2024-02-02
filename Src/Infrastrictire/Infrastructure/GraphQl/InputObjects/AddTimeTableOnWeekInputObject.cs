using GraphQl.InputObjects;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class AddTimeTableOnWeekInputObject
{

    [GraphQLNonNullType]
    public int GroupId {get;set;}
    [GraphQLNonNullType]
    public DateOnly MondayDate {get;set;}

    [GraphQLNonNullType]
    public TimeTableOnDayRecord Monday {get;set;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Tuesday{get;set;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Wednesday{get;set;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Thursday{get;set;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Friday{get;set;}
    [GraphQLNonNullType]
    public TimeTableOnDayRecord Saturday{get;set;}
}
