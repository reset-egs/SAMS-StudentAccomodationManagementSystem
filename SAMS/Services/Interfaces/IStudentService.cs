namespace SAMS.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentByNo(int no);
        public void UpdateStudent(Student student);
        public void AddStudent(Student student);
        public void DeleteStudent(int no);
        public IEnumerable<Student> GetWaitingList();
        public StudentLeasingsViewModel GetStudentLeasings(int no);
    }
}
