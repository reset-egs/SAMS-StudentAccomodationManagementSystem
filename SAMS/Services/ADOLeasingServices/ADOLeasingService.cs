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

        public async Task CreateLeasingAsync(int place_No, Leasing l)
        {
            Student? student = sService.GetWaitingList().FirstOrDefault();
            await service.CreateLeasingAsync(place_No, student, l);
            await sService.UpdateStudentAsync(student);
            await rService.UpdateRoomAsync(place_No, true);
        }

        public async Task<IEnumerable<Leasing>> GetLeasingsAsync()
        {
            return await service.GetLeasingsAsync();
        }
    }
}
