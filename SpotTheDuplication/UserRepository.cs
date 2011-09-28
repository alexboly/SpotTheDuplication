using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SpotTheDuplication
{
    public class UserRepository
    {
        private readonly string connStr;

        public UserRepository(string connStr)
        {
            this.connStr = connStr;
        }

        public ICollection<User> GetUserList()
        {
            ICollection<User> users = new List<User>();
            IDbConnection connection = new SqlConnection(connStr);

            // Start getting data
            using (connection)
            {
                connection.Open();

                // Create the select command
                IDbCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select ID, UserName, Password from Users";

                // Get the users
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);
                    users.Add(new User { ID = id, Name = username, Password = password });
                }

                // Clean up
                reader.Close();
            }
            return users;
        }

        public class User
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public string Password { get; set; }
        }
    }
}