namespace SAMS.Services.ADOStudentServices
{
    public class ADOStudentService : IStudentService
    {
        private ADOStudent service;
        public ADOStudentService(ADOStudent service)
        {
            this.service = service;
        }

        public async Task DeleteStudentAsync(int no)
        {
            await service.DeleteStudentAsync(no);
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
