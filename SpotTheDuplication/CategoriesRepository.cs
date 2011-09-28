using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SpotTheDuplication
{
    public class CategoriesRepository
    {
        private readonly string connStr;

        public CategoriesRepository(string connStr)
        {
            this.connStr = connStr;
        }

        public ICollection<Category> GetCategoryList()
        {
            ICollection<Category> categories = new List<Category>();
            IDbConnection connection = new SqlConnection(connStr);

            // Start getting data
            using (connection)
            {
                connection.Open();

                // Create the select command
                IDbCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select ID, Name from Categories";

                // Get the users
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    categories.Add(new Category { ID = id, Name = name});
                }

                // Clean up
                reader.Close();
            }
            return categories;
        }

        public class Category
        {
            public int ID { get; set; }

            public string Name { get; set; }
        }
    }
}