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

        public StudentLeasingsViewModel GetStudentLeasings(int no)
        {
            StudentLeasingsViewModel s = new StudentLeasingsViewModel();
            string query = $"SELECT Student.Student_No, Student.SName, Leasing.Leasing_No, Leasing.Place_No, Room.Rent_Per_Semester, Room.Dormitory_No, Room.Appart_No FROM Student JOIN Leasing ON Student.Student_No = Leasing.Student_No JOIN Room ON Leasing.Place_No = Room.Place_No WHERE Student.Student_No = {no}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        s.Student_No = Convert.ToInt32(reader[0]);
                        s.SName = Convert.ToString(reader[1]);
                        s.Leasing_No = Convert.ToInt32(reader[2]);
                        s.Place_No = Convert.ToInt32(reader[3]);
                        s.Rent_Per_Semester = Convert.ToInt32(reader[4]);
                        if (reader.IsDBNull(5))
                        {
                            s.Dormitory_No = null;
                            s.Appart_No = Convert.ToInt32(reader[6]);
                        }
                        else
                        {
                            s.Dormitory_No = Convert.ToInt32(reader[5]);
                            s.Appart_No = null;
                        }
                        return s;
                    }
                }
            }
            return s;
        }
    }
}
