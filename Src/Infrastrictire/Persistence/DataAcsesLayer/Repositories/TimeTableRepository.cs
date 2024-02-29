using System.Data.Entity;
using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.App.Interfaces;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;

public class TimeTableRepository : ITimeTableRepository
{
    private readonly UsersDBContext _databaseContext;

    public TimeTableRepository(UsersDBContext context)
    {
        _databaseContext = context;
    }


    public async Task<Result> Add(WeeklySchedule timetable)
    {
        // if(await haveDualisationTimeTableOnWeek(timetable))
        // {
        //     return Result.Failure(new Error("123", "123"));
        // }

        // return await saveTimeTable(timetable);
        return null;
    }

    private async Task<Result> saveTimeTable(WeeklySchedule timetable)
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

    private async Task<bool> haveDualisationTimeTableOnWeek(WeeklySchedule elementForCheck)
    {
        // return await _databaseContext
        // .WeeksTimeTables
        // .Where(
        //     ex =>
        //     ex.Monday.Date == elementForCheck.Monday.Date
        //     &&
        //     ex.GroupId == elementForCheck.GroupId
        // )
        // .AnyAsync();
        return false;
    }

    public async Task<Result> Change(WeeklySchedule changes)
    {
        if(await haveDualisationTimeTableOnWeek(changes) == false)
        {
            return await saveTimeTable(changes);
        }        

        return await updateTimeTable(changes);

    }
    private async Task<Result> updateTimeTable(WeeklySchedule changes)
    {
        // try{
        // var res = await _databaseContext
        // .WeeksTimeTables
        // .Where(
        //     ex =>
        //     ex.Monday.Date == changes.Monday.Date
        //     &&
        //     ex.GroupId == changes.GroupId
        // ).FirstAsync();
        
        // res.Monday = changes.Monday;
        // res.Thusday = changes.Thusday;
        // res.Wensday = changes.Wensday;
        // res.Tuesday = changes.Tuesday;
        // res.Friday = changes.Friday;

        // await _databaseContext.SaveChangesAsync();
        return Result.Sucsesfull();
    // }
    // catch(Exception ex)
    // {
    //     return Result.Failure(new Error("123", ex.Message));
    // }
    // }

    // public Task<Result<TimeTableOnWeek>> GetCurrentTimeTableOnWeekForGroup(Group group)
    // {
    //     throw new NotImplementedException();
     }

    public Task<Result<WeeklySchedule>> GetTimeTableOnWeekForGroupByMondayDate(Group group, DateOnly MondayDate)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(WeeklySchedule changes)
    {
        throw new NotImplementedException();
    }

    public Task<Result<WeeklySchedule>> GetCurrentByGroupId(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetByGroupIdAndStartWeekDate(int groupId, DateOnly date)
    {
        throw new NotImplementedException();
    }
}
