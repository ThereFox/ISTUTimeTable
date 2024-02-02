using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace App.Interfaces.NotEnded;

public interface ICommentsRepository
{
    public Task<Result> Add(Comment comment);
    public Task<Result> Update(int commentId, Comment commentNewInfo);
    public Task<Result> Delete(int commentId);
}
