namespace SAMS.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> GetRooms();
        public IEnumerable<Room> GetVacantRooms();
        public void UpdateRoom(Room room);
    }
}
