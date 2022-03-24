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

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            List<Room> results = new List<Room>();
            string query = "SELECT * FROM Room";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Room r = new Room();
                        r.Place_No = Convert.ToInt32(reader[0]);
                        r.Rent_Per_Semester = Convert.ToInt32(reader[1]);
                        r.Occupied = Convert.ToBoolean(reader[2]);
                        r.Room_No = Convert.ToInt32(reader[3]);
                        if(r.Dormitory_No.HasValue || r.Appart_No.HasValue)
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
        public async Task UpdateRoomAsync(int place_No, bool occupied)
        {
            
            string query = $"UPDATE Room SET Occupied = {occupied}  WHERE Place_No = {place_No}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
