namespace SAMS.Services.ADORoomServices
{
    public class ADORoom
    {
        string connectionString;
        private IConfiguration configuration;
        public ADORoom(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public IEnumerable<Room> GetRooms()
        {
            List<Room> results = new List<Room>();
            string query = "SELECT * FROM Rooms";

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
                        r.Room_No = Convert.ToInt32(reader[1]);
                        r.Rent_Per_Semester = Convert.ToDecimal(reader[2]);
                        r.Occupied = Convert.ToBoolean(reader[3]);
                        results.Add(r);
                    }
                }
            }
            return results;
        }

        public IEnumerable<Room> GetVacantRooms()
        {
            throw new NotImplementedException();
        }

        public void UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
