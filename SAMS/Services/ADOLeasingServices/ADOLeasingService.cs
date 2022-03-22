namespace SAMS.Services.ADOLeasingServices
{
    public class ADOLeasingService : ILeasingService
    {
        private ADOLeasing service;
        private ADOStudent sService;
        private ADORoom rService;

        public ADOLeasingService(ADOLeasing service, ADOStudent sService, ADORoom rService)
        {
            this.service = service;
            this.sService = sService;
            this.rService = rService;
        }

        public void CreateLeasing(int place_No, Leasing l)
        {
            Student student = sService.GetWaitingList().FirstOrDefault();
            service.CreateLeasing(place_No, student, l);
            sService.UpdateStudent(student);
            rService.UpdateRoom(place_No);
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
