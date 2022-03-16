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

        public void CreateLeasing(Leasing leasing)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Leasing> GetLeasings()
        {
            List<Leasing> results = new List<Leasing>();
            string query = "SELECT * FROM Leasings";

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
                        l.Date_From = Convert.ToDateTime(reader[1]);
                        l.Date_To = Convert.ToDateTime(reader[2]);
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
