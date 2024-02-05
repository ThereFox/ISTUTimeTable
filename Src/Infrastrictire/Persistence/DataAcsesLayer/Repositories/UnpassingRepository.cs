using System.Data.Entity;
using ISTUTimeTable.Src.Core.App.Interfaces;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;

public class UnpassingRepository : IUnpassingRepository
{
    private readonly UsersDBContext _databaseContext;

    public async Task Add(Unpassing unpassing)
    {
        _databaseContext.Unpassings.Add(unpassing);
        await _databaseContext.SaveChangesAsync();
    }
    public async Task<List<Unpassing>> GetAllByDay(DateOnly day)
    {
        var query = _databaseContext
        .Unpassings
        .Where(ex => ex.Day.Date == day); 

        var result = await query.ToListAsync();

        return result;
    }
    public async Task<List<Unpassing>> GetAllByDayAndGroup(Group group, DateOnly day)
    {
        var query = _databaseContext
        .Unpassings
        .Where(ex => ex.Day.Date == day && ex.Student.group == group); 

        var result = await query.ToListAsync();

        return result;
    }
    public async Task<List<Unpassing>> GetAllUnpassingByUser(User user)
    {
        var query = _databaseContext
        .Unpassings
        .Where(ex => ex.StudentId == user.Id); 

        var result = await query.ToListAsync();

        return result;
    }

    public Task<Result<List<Unpassing>>> GetByGroupAndDate(int GroupId, DateOnly date)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int unpassingId)
    {
        _databaseContext
        .Remove(
            _databaseContext
            .Unpassings
            .Where(ex => ex.Id == unpassingId)
            .First()
        );
        await _databaseContext.SaveChangesAsync();
    }

    public Task<Result> Update(int UnpassingId, Unpassing unpassing)
    {
        throw new NotImplementedException();
    }

    Task<Result> IUnpassingRepository.Add(Unpassing unpassing)
    {
        throw new NotImplementedException();
    }

    Task<Result> IUnpassingRepository.Remove(int unpassingId)
    {
        throw new NotImplementedException();
    }
}
