using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.DataAcsesLayer;
using Src.Core.App.Interfaces;

namespace DataAcsesLayer.Repositories;

public class TimeTableRepository : ITimeTableRepository
{
    private readonly UsersDBContext _databaseContext;

    public Task Add(TimeTableOnWeek timetable)
    {
        throw new NotImplementedException();
    }

    public Task Change(List<object> changes)
    {
        throw new NotImplementedException();
    }

    public Task DuplicateWeek(Group group)
    {
        throw new NotImplementedException();
    }
}
