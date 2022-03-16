namespace SAMS.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentByNo(int no);
        public void UpdateStudent(Student student);
        public void AddStudent(Student student);
        public IEnumerable<Student> GetWaitingList();
    }
}
