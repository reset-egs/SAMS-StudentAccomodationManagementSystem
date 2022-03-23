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

        public async Task CreateLeasingAsync(int place_No, Student s, Leasing l)
        {
            string query = $"Insert into Leasing Values(@student_No, @place_No, @date_From, @date_To)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("student_No", s.Student_No);
                    command.Parameters.AddWithValue("place_No", place_No);
                    command.Parameters.AddWithValue("date_From", l.Date_From);
                    command.Parameters.AddWithValue("date_To", l.Date_To) ;
                    int numberOfRowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Leasing>> GetLeasingsAsync()
        {
            List<Leasing> results = new List<Leasing>();
            string query = "SELECT * FROM Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
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
    }
}
