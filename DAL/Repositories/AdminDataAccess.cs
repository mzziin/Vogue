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
            string query = "delete from Products where ProductId=@pid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public DataSet Gridbind_Fun()
        {
            string query = "Select * from Products";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter sdr = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                return ds;
            }  
        }
        public void AddProductToDb(string name, string desc, decimal price, int stock, string imageurl, int categoryid)
        {
            int i;
            string query = "Insert into Products values(@name, @desc, @price, @stock, @categoryid, @imgurl)";
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
            string query = "Update Products Set Name = @name, Description = @desc, Price = @price, Stock = @stock, CategoryId = @categoryid, ImageUrl = @imgurl where ProductId=@pid";
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
            string query = "select * from Categories";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlDataAdapter sdr = new SqlDataAdapter(query, conn))
                {
                    sdr.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetOrdersFromDb()
        {
            string query = "select * from Orders";
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
    }
}
