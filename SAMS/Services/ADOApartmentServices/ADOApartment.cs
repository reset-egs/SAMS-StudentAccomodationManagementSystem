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

        public IEnumerable<Room> GetVacantRooms(int no)
        {
            List<Room> results = new List<Room>();
            string query = $"SELECT * FROM Room WHERE Room.Appart_No = {no} AND Room.Occupied != 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room r = new Room();
                        r.Place_No = Convert.ToInt32(reader[0]);
                        r.Rent_Per_Semester = Convert.ToInt32(reader[1]);
                        r.Occupied = Convert.ToBoolean(reader[2]);
                        r.Room_No = Convert.ToInt32(reader[3]);
                        if (r.Dormitory_No.HasValue || r.Appart_No.HasValue)
                        {
                            r.Dormitory_No = Convert.ToInt32(reader[4]);
                            r.Appart_No = Convert.ToInt32(reader[5]);
                        }
                        else
                        {
                            r.Dormitory_No = null;
                            r.Appart_No = null;
                        }

                        results.Add(r);
                    }
                }
            }
            return results;
        }

        public Apartment GetApartmentByNo(int no)
        {
            Apartment result = new Apartment();
            string query = $"SELECT * FROM Appartment WHERE Appartment.Appart_No = {no}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment a = new Apartment();
                        a.Appart_No = Convert.ToInt32(reader[0]);
                        a.Address = Convert.ToString(reader[1]);
                        a.Types = Convert.ToChar(reader[2]);
                        result = a;
                    }
                }
            }
            return result;
        }
    }
}
