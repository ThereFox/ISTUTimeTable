using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateTimeTableOnWeekInputObject
{
    [GraphQLNonNullType]
    public int GroupId {get;}
    [GraphQLNonNullType]
    public DateOnly MondayDate {get;}

    public TimeTableOnDayRecord Monday {get;}

    public TimeTableOnDayRecord Tuesday {get;}

    public TimeTableOnDayRecord Wednesday {get;}

    public TimeTableOnDayRecord Thursday {get;}

    public TimeTableOnDayRecord Friday {get;}

    public TimeTableOnDayRecord Saturday {get;}

    public UpdateTimeTableOnWeekInputObject(
        int groupId,
        DateOnly mondayDate,
        TimeTableOnDayRecord? monday,
        TimeTableOnDayRecord? tuesday,
        TimeTableOnDayRecord? wednesday,
        TimeTableOnDayRecord? thursday,
        TimeTableOnDayRecord? friday,
        TimeTableOnDayRecord? saturday
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
