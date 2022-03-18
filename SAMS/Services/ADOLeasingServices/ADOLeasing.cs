namespace SAMS.Services.ADOLeasingServices
{
    public class ADOLeasing
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOLeasing(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public void CreateLeasing(int place_No, Student s, Leasing l)
        {
            string query = $"Insert into Leasing Values(@student_No, @place_No, @date_From, @date_To)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("student_No", s.Student_No);
                    command.Parameters.AddWithValue("place_No", place_No);
                    command.Parameters.AddWithValue("date_From", l.Date_From);
                    command.Parameters.AddWithValue("date_To", l.Date_To) ;
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Leasing> GetLeasings()
        {
            List<Leasing> results = new List<Leasing>();
            string query = "SELECT * FROM Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Leasing l = new Leasing();
                        l.Leasing_No = Convert.ToInt32(reader[0]);
                        l.Student_No = Convert.ToInt32(reader[1]);
                        l.Place_No = Convert.ToInt32(reader[2]);
                        l.Date_From = Convert.ToDateTime(reader[3]);
                        l.Date_To = Convert.ToDateTime(reader[4]);
                        results.Add(l);
                    }
                }
            }
            return results;
        }

        public void UpdateLeasing(Leasing leasing)
        {
            throw new NotImplementedException();
        }
    }
}
