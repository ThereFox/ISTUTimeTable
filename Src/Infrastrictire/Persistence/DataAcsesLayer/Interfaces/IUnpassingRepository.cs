using DataAcsesLayer.Entitys;
using ISTUTimeTable.Src.Core.Common;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface IUnpassingRepository
    {
        public Task<Result> Add(Unpassings unpassing);
        public Task<Result> Remove(int unpassingId);
        public Task<Result> Update(int UnpassingId, Unpassings unpassing);
        public Task<Result<List<Unpassings>>> GetByGroupAndDate(int GroupId, DateOnly date);
    }
}