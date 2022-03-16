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
    }
}
