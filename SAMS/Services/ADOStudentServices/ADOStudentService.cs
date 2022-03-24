namespace SAMS.Services.ADOStudentServices
{
    public class ADOStudentService : IStudentService
    {
        private ADOStudent service;
        private ADORoom rService;
        public ADOStudentService(ADOStudent service, ADORoom rService)
        {
            this.service = service;
            this.rService = rService;
        }

        public async Task DeleteStudentAsync(int no)
        {
            await service.DeleteStudentAsync(no);
            rService.UpdateRoomAsync(no, false);
        }


        public async Task<Student> GetStudentByNoAsync(int no)
        {
            return await service.GetStudentByNoAsync(no);
        }

        public async Task<StudentLeasingsViewModel> GetStudentLeasingsAsync(int no)
        {
            return await service.GetStudentLeasingsAsync(no);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await service.GetStudentsAsync();
        }

        public IEnumerable<Student> GetWaitingList()
        {
            return service.GetWaitingList();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await service.UpdateStudentAsync(student);
        }

    }
}
