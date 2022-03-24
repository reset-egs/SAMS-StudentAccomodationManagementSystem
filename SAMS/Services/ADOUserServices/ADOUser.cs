namespace SAMS.Services.ADOUserServices
{
    public class ADOUser
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOUser(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public async Task SignUpAsync(string username, string password, int studentNo)
        {
            string query = "INSERT INTO StudentUser VALUES(@username, HASHBYTES('SHA2_256',@password), @student_No)";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    command.Parameters.AddWithValue("student_No", studentNo);
                    int numberOfRowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            User result = new User();
            string query = $"SELECT * FROM StudentUser WHERE StudentUser.Username = '{username}' AND StudentUser.Password = HASHBYTES('SHA2_256', @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("password", password);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        User u = new User();
                        u.Id = Convert.ToInt32(reader[0]);
                        u.Username = Convert.ToString(reader[1]);
                        u.Password = null;
                        u.Student_No = Convert.ToInt32(reader[3]);
                        result = u;
                    }
                }
            }
            return result;
        }

        public async Task<Message> GetMessageAsync(string username)
        {
            Message message = new Message();
            string query = $"SELECT * FROM Message WHERE STR(Message.Student_No) = {username}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while(await reader.ReadAsync())
                    {
                        Message m = new Message();
                        m.Id = Convert.ToInt32(reader[0]);
                        m.Student_No = Convert.ToInt32(reader[1]);
                        m.MessageText = Convert.ToString(reader[2]);
                        message = m;
                    }
                }
            }
            return message;
        }
    }
}
