namespace ISTUTimeTable.Src.Core.Domain.Entitys;

    public class Location
    {
        public int id;
        public int CampusNumber;
        public int FloorNumber;
        public int ClassRoomNumber;

        public List<Lesson> Lessons { get; set; }
    }
