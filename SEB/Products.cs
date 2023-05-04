using System.Collections.Generic;
using System.Data.SqlClient;




//defining Product
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    public static List<Product> GetByCategoryId(int categoryId, string connectionString)
    {
        List<Product> products = new List<Product>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Price FROM Products WHERE CategoryId = @CategoryId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryId", categoryId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    CategoryId = categoryId
                };
                products.Add(product);
            }
        }

        return products;
    }
}