using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface ITimeTableRepository
    {
        public Task<Result> Add(TimeTableOnWeek timetable);
        public Task<Result> Update(TimeTableOnWeek changes);
        public Task<Result<TimeTableOnWeek>> GetCurrentByGroupId(int groupId);
        public Task<Result> GetByGroupIdAndStartWeekDate(int groupId, DateOnly date);        
    }
}