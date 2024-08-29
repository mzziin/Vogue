using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Repositories
{
    public class CartDataAccess
    {
        private readonly string _connectionString;
        public CartDataAccess()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }
        public int Create(int Uid, int Pid, int quantity, decimal unitprice, decimal totalprice, string pname, string imgurl)
        {
            int i;
            string query = "Insert into Cart values (@uid, @pid, @quantity, @unitprice, @totalprice, @pname, @imageurl)";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Uid);
                    cmd.Parameters.AddWithValue("@pid", Pid);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@unitprice", unitprice);
                    cmd.Parameters.AddWithValue("@totalprice", totalprice);
                    cmd.Parameters.AddWithValue("@pname", pname);
                    cmd.Parameters.AddWithValue("@imageurl", imgurl);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int Update(int Cid, int qty)
        {
            int i;
            string query = "update Cart Set Quantity=@qty where CartId=@cid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", Cid);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public string GetTotal(int uid)
        {
            string sum;
            string query = "select sum(TotalPrice) from Cart where UserId=@uid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    sum = cmd.ExecuteScalar().ToString();
                }
            }
            return sum;
        }
        public int Update(int Pid,int Uid, int qty, decimal totalprice)
        {
            int i;
            string query = "update Cart Set Quantity=@qty, TotalPrice=@totalprice where ProductId=@pid and UserId=@uid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", Pid);
                    cmd.Parameters.AddWithValue("@uid", Uid);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@totalprice", totalprice);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public object QtyOfId(int uid, int pid)
        {
            object count;
            string query = "Select Quantity from Cart where ProductId=@pid and UserId=@uid"
;           using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    count = cmd.ExecuteScalar();
                }
            }
            return count;
        }

        public int Delete(int Cid)
        {
            int i;
            string query = "delete from Cart where CartId=@cid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", Cid);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public List<CartEntity> Read(int Uid)
        {
            List<CartEntity> cartProducts = new List<CartEntity>();
            
            string query = "select * from Cart where UserId=@uid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Uid);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CartEntity cartItem = new CartEntity
                        {
                            CartId = Convert.ToInt32(sdr["CartId"]),
                            UserId = Convert.ToInt32(sdr["UserId"]),
                            ProductId = Convert.ToInt32(sdr["ProductId"]),
                            Quantity = Convert.ToInt32(sdr["Quantity"]),
                            UnitPrice = Convert.ToInt32(sdr["UnitPrice"]),
                            TotalPrice = Convert.ToInt32(sdr["TotalPrice"]),
                            ProductName = sdr["ProductName"].ToString(),
                            ImageUrl = sdr["ImageUrl"].ToString()
                        };
                        cartProducts.Add(cartItem);
                    }
                }
            }
            return cartProducts;
        }

    }
}
