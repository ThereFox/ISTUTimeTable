using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface IUnpassingRepository
    {
        public Task<Result> Add(Unpassing unpassing);
        public Task<Result> Remove(int unpassingId);
        public Task<Result> Update(int UnpassingId, Unpassing unpassing);
        public Task<Result<List<Unpassing>>> GetByGroupAndDate(int GroupId, DateOnly date);
    }
}