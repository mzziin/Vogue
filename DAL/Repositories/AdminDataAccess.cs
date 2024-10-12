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
    public class AdminDataAccess
    {
        private readonly string _connectionString;
        public AdminDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public int Delete(int productId)
        {
            int i;
            string query = "DELETE FROM Products WHERE ProductId=@pid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@pid", productId);
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }

        public DataSet Gridbind_Fun()
        {
            string query = "SELECT * FROM Products";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlDataAdapter sdr = new SqlDataAdapter(query, conn))
                {
                    conn.Open();
                    sdr.Fill(ds);
                }
            }
            return ds;
        }

        public void AddProductToDb(string name, string desc, decimal price, int stock, string imageurl, int categoryid)
        {
            int i;
            string query = "INSERT INTO Products VALUES (@name, @desc, @price, @stock, @categoryid, @imgurl)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    cmd.Parameters.AddWithValue("@imgurl", imageurl);

                    i = cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProductFromDb(string name, string desc, decimal price, int stock, string imageurl, int categoryid, int pid)
        {
            int i;
            string query = "UPDATE Products SET Name = @name, Description = @desc, Price = @price, Stock = @stock, CategoryId = @categoryid, ImageUrl = @imgurl WHERE ProductId=@pid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    cmd.Parameters.AddWithValue("@imgurl", imageurl);

                    i = cmd.ExecuteNonQuery();
                }
            }

        }

        public DataTable GetCategories()
        {
            string query = "SELECT * FROM Categories";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlDataAdapter sdr = new SqlDataAdapter(query, conn))
                {
                    conn.Open();
                    sdr.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetOrdersFromDb()
        {
            string query = @"SELECT * FROM Orders 
                            ORDER BY CASE 
                            WHEN OrderStatus = 'Pending' THEN 1 
                            WHEN OrderStatus = 'Packed' THEN 2 
                            WHEN OrderStatus = 'Shipped' THEN 3 
                            ELSE 4 
                            END";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlDataAdapter sdr = new SqlDataAdapter(query, conn))
                {
                    conn.Open();
                    sdr.Fill(dt);
                }
            }
            return dt;
        }

        public void UpdateOrderStatus(int orderId, string orderStatus)
        {
            string query = "UPDATE Orders SET OrderStatus = @status WHERE OrderId=@oId";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", orderStatus);
                    cmd.Parameters.AddWithValue("@oId", orderId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string CheckStatus(int orderId)
        {
            string status;
            string query = "SELECT OrderStatus FROM Orders WHERE OrderId=@oId";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd =new SqlCommand(query, conn))
                {
                    conn.Open();
                    status = cmd.ExecuteScalar().ToString();
                }
            }
            return status;
        }
    }
}
