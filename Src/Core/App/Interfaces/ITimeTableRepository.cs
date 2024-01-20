using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface ITimeTableRepository
    {
        public Task<Result> Add(TimeTableOnWeek timetable);
        public Task<Result> Change(TimeTableOnWeek changes);
        public Task<Result<TimeTableOnWeek>> GetCurrentTimeTableOnWeekForGroup(Group group);
        public Task<Result<TimeTableOnWeek>> GetTimeTableOnWeekForGroupByMondayDate(Group group, DateOnly MondayDate);
        
    }
}