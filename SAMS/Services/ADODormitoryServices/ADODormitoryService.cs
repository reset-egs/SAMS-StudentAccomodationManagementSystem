namespace SAMS.Services.ADODormitoryServices
{
    public class ADODormitoryService : IDormitoryService
    {
        private ADODormitory service;
        public ADODormitoryService(ADODormitory service)
        {
            this.service = service;
        }

        public IEnumerable<Dormitory> GetDormitories()
        {
            return service.GetDormitories();
        }

        public Dormitory GetDormitoryByNo(int no)
        {
            return service.GetDormitoryByNo(no);
        }

        public IEnumerable<Room> GetVacantRooms(int no)
        {
            return service.GetVacantRooms(no);
        }
    }
}
