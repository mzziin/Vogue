using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Repositories
{
    public class CartRepository
    {
        private readonly string _connectionString;
        public CartRepository()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }
        public int Add(int Uid, int Pid, int quantity, decimal unitprice, decimal totalprice)
        {
            int i;
            string query = "Insert into Cart values (@uid, @pid, @quantity, @unitprice, @totalprice)";
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

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }

        public int Delete(int Cid)
        {
            int i;
            string query = "delete from Cart where CartId=@cid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", Cid);

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public List<CartEntity> Get()
        {
            List<CartEntity> cartProducts = new List<CartEntity>();
            CartEntity cartItem;
            string query = "select * from Cart";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        cartItem = new CartEntity
                        {
                            CartId = Convert.ToInt32(sdr["CartId"]),
                            UserId = Convert.ToInt32(sdr["UserId"]),
                            ProductId = Convert.ToInt32(sdr["ProductId"]),
                            Quantity = Convert.ToInt32(sdr["Quantity"]),
                            UnitPrice = Convert.ToInt32(sdr["UnitPrice"]),
                            TotalPrice = Convert.ToInt32(sdr["TotalPrice"]),
                        };
                        cartProducts.Add(cartItem);
                    }
                }
            }
            return cartProducts;
        }
    }
}
