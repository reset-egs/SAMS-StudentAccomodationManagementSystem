﻿namespace SAMS.Services.ADODormitoryServices
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
            string query = "SELECT * FROM Dormitory";

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

        public IEnumerable<Room> GetVacantRooms(int no)
        {
            List<Room> results = new List<Room>();
            string query = $"SELECT * FROM Room WHERE Room.Dormitory_No = {no} AND Room.Occupied != 1";

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

        public Dormitory GetDormitoryByNo(int no)
        {
            Dormitory result = new Dormitory();
            string query = $"SELECT * FROM Dormitory WHERE Dormitory.Dormitory_No = {no}";

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
                        result = d;
                    }
                }
            }
            return result;
        }
    }
}
