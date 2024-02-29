using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.Common;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface ITimeTableRepository
    {
        public Task<Result> Add(WeeklySchedule timetable);
        public Task<Result> Update(WeeklySchedule changes);
        public Task<Result<WeeklySchedule>> GetCurrentByGroupId(int groupId);
        public Task<Result> GetByGroupIdAndStartWeekDate(int groupId, DateOnly date);        
    }
}