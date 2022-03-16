﻿namespace SAMS.Services.ADOStudentServices
{
    public class ADOStudentService : IStudentService
    {
        private ADOStudent service;
        public ADOStudentService(ADOStudent service)
        {
            this.service = service;
        }

        public void AddStudent(Student student)
        {
            service.AddStudent(student);
        }

        public Student GetStudentByNo(int no)
        {
            return service.GetStudentByNo(no);
        }

        public IEnumerable<Student> GetStudents()
        {
            return service.GetStudents();
        }

        public IEnumerable<Student> GetWaitingList()
        {
            return service.GetWaitingList();
        }

        public void UpdateStudent(Student student)
        {
            service.UpdateStudent(student);
        }
    }
}
