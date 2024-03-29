using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace App.Interfaces;

public interface IGroupRepository
{
    public Task<Result<List<Group>>> GetAll();
    public Task<Result> Add(Group group);
    public Task<Result<Group>> GetById(int Id);
    public Task<Result> Update(int Id, Group newGroupInfo);
    public Task<Result> RemoveById(int Id);
}
