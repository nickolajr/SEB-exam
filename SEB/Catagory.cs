using System.Collections.Generic;
using System.Data.SqlClient;



//defining catagory
class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public static List<Category> GetAll(string connectionString)
    {
        List<Category> categories = new List<Category>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name FROM Categories";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                categories.Add(category);
            }
        }

        return categories;
    }
}