using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitys.Unpassings;
using ISTUTimeTable.Entitys;
using ISTUTImeTable.DataAcsesLayer;
using Src.Core.App.Interfaces;

namespace DataAcsesLayer.Repositories;

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
        throw new NotImplementedException();
    }

    public async Task<List<Unpassing>> GetAllByDay(Group group, DateOnly day)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int unpassingId)
    {
        _databaseContext.Remove(_databaseContext.Unpassings.Where(ex => ex.Id == unpassingId).First());
        await _databaseContext.SaveChangesAsync();
    }
}
