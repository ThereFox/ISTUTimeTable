using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.Common;

namespace Src.Core.App.Interfaces
{
    public interface ITimeTableRepository
    {
        public Task<Result> Add(TimeTableOnWeek timetable);
        public Task<Result> Change(TimeTableOnWeek changes);
    }
}