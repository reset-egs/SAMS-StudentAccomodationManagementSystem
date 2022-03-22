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
            Student result = new Student();

            string query = $"SELECT * FROM Student WHERE Student.Student_No = {no}";

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
                        result = s;
                    }
                }
            }
            return result;
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
            List<Student> waitingList = new List<Student>();
            string query = "SELECT * FROM Student WHERE Student.Has_Room != 1 ORDER BY Student.Registration_Date";

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
                        waitingList.Add(s);
                    }
                }
            }
            return waitingList;
        }

        public void DeleteStudent(int no)
        {
            string query = $"DELETE FROM Student WHERE Student.Student_No = {no}";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            string query = $"UPDATE Student SET Has_Room = 1  WHERE Student_No = {student.Student_No}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            } 
        }
    }
}
