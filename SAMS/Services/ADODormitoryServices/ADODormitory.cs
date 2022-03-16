namespace SAMS.Services.ADODormitoryServices
{
    public class ADODormitory
    {
        string connectionString;
        private IConfiguration configuration;
        public ADODormitory(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public IEnumerable<Dormitory> GetDormitories()
        {
            List<Dormitory> results = new List<Dormitory>();
            string query = "SELECT * FROM Dormitories";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Dormitory d = new Dormitory();
                        d.Dormitory_No = Convert.ToInt32(reader[0]);
                        d.Name = Convert.ToString(reader[1]);
                        d.Address = Convert.ToString(reader[2]);
                        results.Add(d);
                    }
                }
            }
            return results;
        }
    }
}
