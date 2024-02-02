using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateTimeTableOnWeekInputObject
{
    [GraphQLNonNullType]
    public int GroupId {get;set;}
    [GraphQLNonNullType]
    public DateOnly MondayDate {get;set;}

    public TimeTableOnDayRecord Monday {get;set;}

    public TimeTableOnDayRecord Tuesday {get;set;}

    public TimeTableOnDayRecord Wednesday {get;set;}

    public TimeTableOnDayRecord Thursday {get;set;}

    public TimeTableOnDayRecord Friday {get;set;}

    public TimeTableOnDayRecord Saturday {get;set;}

}
