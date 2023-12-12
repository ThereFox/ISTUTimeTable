using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;
using ISTUTImeTable.DataAcsesLayer;
using Src.Core.App.Interfaces;

namespace DataAcsesLayer.Repositories;

public class TimeTableRepository : ITimeTableRepository
{
    private readonly UsersDBContext _databaseContext;

    public async Task<Result> Add(TimeTableOnWeek timetable)
    {
        if(await haveDualisationTimeTableOnWeek(timetable))
        {
            return Result.Failure(new Error("123", "123"));
        }

        _databaseContext.Add(timetable);
        await _databaseContext.SaveChangesAsync();
        return Result.Sucsesfull();
    }

    private async Task<bool> haveDualisationTimeTableOnWeek(TimeTableOnWeek elementForCheck)
    {
        return await _databaseContext
        .WeeksTimeTables
        .Where(
            ex =>
            ex.Monday.Date == elementForCheck.Monday.Date
            &&
            ex.GroupId == elementForCheck.GroupId
        )
        .AnyAsync();
    }

    public Task Change(List<object> changes)
    {
        throw new NotImplementedException();
    }
}
