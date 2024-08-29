using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Repositories
{
    public class AdminDataAccess
    {
        private readonly string _connectionString;
        public AdminDataAccess()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }

        public int Delete(int pid)
        {
            int i;
            string query = "delete from Products where ProductId=@pid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    i = cmd.ExecuteNonQuery();
                    
                }
            }
            return i;
        }
        public DataSet Gridbind_Fun()
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "Select * from Products";
                SqlDataAdapter sdr = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                return ds;
            }
            
        }
        public void Add(string name, string desc, decimal price, int stock, string imageurl, int categoryid)
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
        public void Update(string name, string desc, decimal price, int stock, string imageurl, int categoryid, int pid)
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
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter sdr = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                return dt;
            }
        }
    }
}
