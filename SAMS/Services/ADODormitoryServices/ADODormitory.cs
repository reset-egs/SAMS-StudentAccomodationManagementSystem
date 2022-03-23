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

        public async Task<IEnumerable<Dormitory>> GetDormitoriesAsync()
        {
            List<Dormitory> results = new List<Dormitory>();
            string query = "SELECT * FROM Dormitory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
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

        public async Task<IEnumerable<Room>> GetVacantRoomsAsync(int no)
        {
            List<Room> results = new List<Room>();
            string query = $"SELECT * FROM Room WHERE Room.Dormitory_No = {no} AND Room.Occupied != 1";

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

        public async Task<Dormitory> GetDormitoryByNoAsync(int no)
        {
            Dormitory result = new Dormitory();
            string query = $"SELECT * FROM Dormitory WHERE Dormitory.Dormitory_No = {no}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Dormitory d = new Dormitory();
                        d.Dormitory_No = Convert.ToInt32(reader[0]);
                        d.Name = Convert.ToString(reader[1]);
                        d.Address = Convert.ToString(reader[2]);
                        result = d;
                    }
                }
            }
            return result;
        }
    }
}
