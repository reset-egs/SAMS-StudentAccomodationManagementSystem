namespace SAMS.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<Room>> GetRoomsAsync();
        public Task UpdateRoomAsync(int place_No);
    }
}
