namespace SAMS.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByNoAsync(int no);
        public Task UpdateStudentAsync(Student student);
        public Task DeleteStudentAsync(int no);
        public IEnumerable<Student> GetWaitingList();
        public Task<StudentLeasingsViewModel> GetStudentLeasingsAsync(int no);
    }
}
