namespace SAMS.Interfaces
{
    public interface IDormitoryService
    {
        public Task<IEnumerable<Dormitory>> GetDormitoriesAsync();
        public Task<Dormitory> GetDormitoryByNoAsync(int no);
        public Task<IEnumerable<Room>> GetVacantRoomsAsync(int no);
    }
}
