using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;
using System.Configuration;

namespace DAL.Repositories
{
    public class CartDataAccess
    {
        private readonly string _connectionString;
        public CartDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public int Create(int userId, int productId, int quantity, decimal unitPrice, decimal totalPrice, string productName, string imgURL)
        {
            int i;
            string query = "Insert into Cart values (@uid, @pid, @quantity, @unitprice, @totalprice, @pname, @imageurl)";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@unitprice", unitPrice);
                    cmd.Parameters.AddWithValue("@totalprice", totalPrice);
                    cmd.Parameters.AddWithValue("@pname", productName);
                    cmd.Parameters.AddWithValue("@imageurl", imgURL);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int Update(int cId, int qty)
        {
            int i;
            string query = "update Cart Set Quantity=@qty where CartId=@cid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", cId);
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

        public int DeleteByUser(int uid)
        {
            int i;
            string query = "delete from Cart where UserId=@uid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int DeleteByProduct(int pId)
        {
            int i;
            string query = "delete from Cart where ProductId=@pId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pId", pId);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int Delete(int pid, int uid)
        {
            int i;
            string query = "delete from Cart where ProductId=@pid and UserId=@uid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@uid", uid);

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

        public List<CartEntity> ReadProductsInStock(int Uid)
        {
            List<CartEntity> cartProducts = new List<CartEntity>();
       
            string query = "select * from Cart where UserId=@uid and ProductId IN (select ProductId from Products where Stock > 0) ";
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
