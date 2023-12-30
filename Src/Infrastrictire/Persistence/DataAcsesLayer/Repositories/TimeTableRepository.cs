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

        return await saveTimeTable(timetable);
    }

    private async Task<Result> saveTimeTable(TimeTableOnWeek timetable)
    {
        try{
            _databaseContext.Add(timetable);
            await _databaseContext.SaveChangesAsync();
            return Result.Sucsesfull();
        }
        catch(Exception ex)
        {
            return Result.Failure(new Error("112", ex.Message));
        }
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

    public async Task<Result> Change(TimeTableOnWeek changes)
    {
        if(await haveDualisationTimeTableOnWeek(changes) == false)
        {
            return await saveTimeTable(changes);
        }        

        return await updateTimeTable(changes);

    }
    private async Task<Result> updateTimeTable(TimeTableOnWeek changes)
    {
        try{
        var res = await _databaseContext
        .WeeksTimeTables
        .Where(
            ex =>
            ex.Monday.Date == changes.Monday.Date
            &&
            ex.GroupId == changes.GroupId
        ).FirstAsync();
        
        res.Monday = changes.Monday;
        res.Thusday = changes.Thusday;
        res.Wensday = changes.Wensday;
        res.Tuesday = changes.Tuesday;
        res.Friday = changes.Friday;

        await _databaseContext.SaveChangesAsync();
        return Result.Sucsesfull();
    }
    catch(Exception ex)
    {
        return Result.Failure(new Error("123", ex.Message));
    }
    }
}
