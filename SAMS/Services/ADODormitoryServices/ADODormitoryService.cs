namespace SAMS.Services.ADODormitoryServices
{
    public class ADODormitoryService : IDormitoryService
    {
        private ADODormitory service;
        public ADODormitoryService(ADODormitory service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Dormitory>> GetDormitoriesAsync()
        {
            return await service.GetDormitoriesAsync();
        }

        public async Task<Dormitory> GetDormitoryByNoAsync(int no)
        {
            return await service.GetDormitoryByNoAsync(no);
        }

        public async Task<IEnumerable<Room>> GetVacantRoomsAsync(int no)
        {
            return await service.GetVacantRoomsAsync(no);
        }
    }
}
