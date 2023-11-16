using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace Src.Core.App.Interfaces
{
    public interface ITimeTableRepository
    {
        public Task DuplicateWeek(Group group);
        public Task Add(TimeTableOnWeek timetable);
        public Task Change(List<object> changes);
    }
}