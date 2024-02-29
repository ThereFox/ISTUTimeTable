using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.Common;

namespace App.Interfaces.NotEnded;

public interface ICommentsRepository
{
    public Task<Result> Add(Comments comment);
    public Task<Result> Update(int commentId, Comments commentNewInfo);
    public Task<Result> Delete(int commentId);
}
