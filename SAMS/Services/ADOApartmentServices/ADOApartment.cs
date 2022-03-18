namespace SAMS.Services.ADOApartmentServices
{
    public class ADOApartment
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOApartment(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public IEnumerable<Apartment> GetApartments()
        {
            List<Apartment> results = new List<Apartment>();
            string query = "SELECT * FROM Appartment";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment a = new Apartment();
                        a.Appart_No = Convert.ToInt32(reader[0]);
                        a.Address = Convert.ToString(reader[1]);
                        a.Types = Convert.ToChar(reader[2]);
                        results.Add(a);
                    }
                }
            }
            return results;
        }
    }
}
