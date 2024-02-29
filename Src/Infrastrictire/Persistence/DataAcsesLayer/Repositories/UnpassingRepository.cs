using System.Data.Entity;
using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.App.Interfaces;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;

public class UnpassingRepository : IUnpassingRepository
{
    private readonly UsersDBContext _databaseContext;

    public async Task Add(Unpassings unpassing)
    {
        _databaseContext.Unpassings.Add(unpassing);
        await _databaseContext.SaveChangesAsync();
    }
    public async Task<List<Unpassings>> GetAllByDay(DateOnly day)
    {
        // var query = _databaseContext
        // .Unpassings
        // .Where(ex => ex.Day.Date == day); 

        // var result = await query.ToListAsync();

        // return result;
        return null;
    }
    public async Task<List<Unpassings>> GetAllByDayAndGroup(Group group, DateOnly day)
    {
        // var query = _databaseContext
        // .Unpassings
        // .Where(ex => ex.Day.Date == day && ex.Student.group == group); 

        // var result = await query.ToListAsync();

        // return result;
        return null;
    }
    public async Task<List<Unpassings>> GetAllUnpassingByUser(User user)
    {
        var query = _databaseContext
        .Unpassings
        .Where(ex => ex.StudentId == user.Id); 

        var result = await query.ToListAsync();

        return result;
    }

    public Task<Result<List<Unpassings>>> GetByGroupAndDate(int GroupId, DateOnly date)
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

    public Task<Result> Update(int UnpassingId, Unpassings unpassing)
    {
        throw new NotImplementedException();
    }

    Task<Result> IUnpassingRepository.Add(Unpassings unpassing)
    {
        throw new NotImplementedException();
    }

    Task<Result> IUnpassingRepository.Remove(int unpassingId)
    {
        throw new NotImplementedException();
    }
}
