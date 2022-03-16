namespace SAMS.Services.ADOLeasingServices
{
    public class ADOLeasingService : ILeasingService
    {
        private ADOLeasing service;
        public ADOLeasingService(ADOLeasing service)
        {
            this.service = service;
        }

        public void CreateLeasing(Leasing leasing)
        {
            service.CreateLeasing(leasing);
        }

        public IEnumerable<Leasing> GetLeasings()
        {
            return service.GetLeasings();
        }

        public void UpdateLeasing(Leasing leasing)
        {
            service.UpdateLeasing(leasing);
        }
    }
}
