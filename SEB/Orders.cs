using SEB;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;


//defining order
class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail> Details { get; set; }

    public void Insert(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Insert order
                string orderQuery = "INSERT INTO Orders (Date, TotalPrice) VALUES (@Date, @TotalPrice); SELECT CAST(scope_identity() AS int)";
                SqlCommand orderCommand = new SqlCommand(orderQuery, connection, transaction);
                orderCommand.Parameters.AddWithValue("@Date", Date);
                orderCommand.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                int orderId = (int)orderCommand.ExecuteScalar();
                Id = orderId;

                // Insert order details
                foreach (OrderDetail detail in Details)
                {
                    string detailQuery = "INSERT INTO OrderDetails (OrderId, ProductId, Quantity) VALUES (@OrderId, @ProductId, @Quantity)";
                    SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction);
                    detailCommand.Parameters.AddWithValue("@OrderId", orderId);
                    detailCommand.Parameters.AddWithValue("@ProductId", detail.Product.Id);
                    detailCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                    detailCommand.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
