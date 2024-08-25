using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }

        public int AddUser(UserEntity user)
        {
            int i;
            string query = "insert into users values(@FullName, @Username, @Email, @Password, @Role, @Phone, @Address, @ZipCode)";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ZipCode", user.ZipCode);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public string GetCountOfId(string username, string password)
        {
            string s;
            string query = "select count(UserId) from Users where Username=@uname and Password=@pwd";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    s = cmd.ExecuteScalar().ToString();
                }
            }
            return s;
        }
        public string GetRole(string uname, string pwd)
        {
            string role;
            string query = "select Role from Users where username=@username and password=@pwd";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", uname);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    role = cmd.ExecuteScalar().ToString();
                }
            }
            return role;
        }
        public int GetId(string uname, string pwd)
        {
            int id;
            string query = "select UserId from Users where Username=@uname and Password=@pwd";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uname", uname);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
            return id;
        }
    }
}
