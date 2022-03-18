namespace SAMS.Interfaces
{
    public interface IDormitoryService
    {
        public IEnumerable<Dormitory> GetDormitories();
        public Dormitory GetDormitoryByNo(int no);
        public IEnumerable<Room> GetVacantRooms(int no);
    }
}
