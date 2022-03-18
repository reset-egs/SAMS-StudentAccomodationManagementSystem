namespace SAMS.Services.ADOLeasingServices
{
    public class ADOLeasingService : ILeasingService
    {
        private ADOLeasing service;
        private ADOStudent sService;

        public ADOLeasingService(ADOLeasing service, ADOStudent sService)
        {
            this.service = service;
            this.sService = sService;
        }

        public void CreateLeasing(int place_No, Leasing l)
        {
            Student student = sService.GetWaitingList().FirstOrDefault();
            service.CreateLeasing(place_No, student, l);
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
