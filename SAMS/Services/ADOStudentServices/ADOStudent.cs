namespace SAMS.Services.ADOStudentServices
{
    public class ADOStudent
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOStudent(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByNo(int no)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> results = new List<Student>();
            string query = "SELECT * FROM Student";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student s = new Student();
                        s.Student_No = Convert.ToInt32(reader[0]);
                        s.SName = Convert.ToString(reader[1]);
                        s.SAddress = Convert.ToString(reader[2]);
                        s.Has_Room = Convert.ToBoolean(reader[3]);
                        s.Registration_Date = Convert.ToDateTime(reader[4]);
                        results.Add(s);
                    }
                }
            }
            return results;
        }

        public IEnumerable<Student> GetWaitingList()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
