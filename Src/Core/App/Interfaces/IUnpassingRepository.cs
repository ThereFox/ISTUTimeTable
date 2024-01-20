using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Core.App.Interfaces
{
    public interface IUnpassingRepository
    {
        public Task<List<Unpassing>> GetAllByDay(DateOnly day); 
        public Task<List<Unpassing>> GetAllByDayAndGroup(Group group, DateOnly day);
        public Task<List<Unpassing>> GetAllUnpassingByUser(User user);
        public Task Add(Unpassing unpassing);
        public Task Remove(int unpassingId);
    }
}