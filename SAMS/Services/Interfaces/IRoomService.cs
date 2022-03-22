namespace SAMS.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> GetRooms();
        public void UpdateRoom(int place_No);
    }
}
