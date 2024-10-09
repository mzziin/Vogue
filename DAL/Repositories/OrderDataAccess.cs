using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL.Repositories
{
    public class OrderDataAccess
    {
        private readonly string _connectionString;
        public OrderDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public int AddToOrderTable(int userId, string orderDate, decimal totalPrice, string orderStatus, string paymentMethod, string address)
        {
            int orderId;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Orders (UserId, OrderDate, TotalAmount, OrderStatus, PaymentMethod, ShippingAddress)
                         OUTPUT INSERTED.OrderId
                         VALUES (@UserId, @OrderDate, @TotalAmount, @OrderStatus, @PaymentMethod, @ShippingAddress)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameters to the command
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalPrice);
                    cmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@ShippingAddress", address);

                    conn.Open();

                    // Execute the query and get the OrderId
                    orderId = (int)cmd.ExecuteScalar();
                }
            }
            return orderId;
        }


        public void AddToOrderDetailTable(int orderId, int pId, int Qty, int unitPrice, decimal totalPrice)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, TotalPrice)
                         VALUES (@orderId, @pId, @Qty, @unitPrice, @totalPrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@pId", pId);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
