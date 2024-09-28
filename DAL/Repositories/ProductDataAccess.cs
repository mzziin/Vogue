using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;
using System.Data;

namespace DAL.Repositories
{
    public class ProductDataAccess
    {
        private readonly string _connectionString;
        public ProductDataAccess()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }

        public List<ProductEntity> GetAllProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>(); // list of type ProductEntity
            string query = "Select * from Products where Stock > 0";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ProductEntity product = new ProductEntity
                        {
                            ProductId = Convert.ToInt32(sdr["ProductId"]),
                            Name = sdr["Name"].ToString(),
                            Description = sdr["Description"].ToString(),
                            Stock = Convert.ToInt32(sdr["Stock"]),
                            Price = Convert.ToDecimal(sdr["Price"]),
                            CategoryId = Convert.ToInt32(sdr["CategoryId"]),
                            ImageUrl = sdr["ImageUrl"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }
            return products; // return the product list which can be used as the datasource for repeater or gridview
        }
        public List<ProductEntity> GetAllProductsOnCategory(int cid)
        {
            List<ProductEntity> products = new List<ProductEntity>(); // list of type ProductEntity
            string query = "Select * from Products where CategoryId=@cid and Stock > 0";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", cid);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ProductEntity product = new ProductEntity
                        {
                            ProductId = Convert.ToInt32(sdr["ProductId"]),
                            Name = sdr["Name"].ToString(),
                            Description = sdr["Description"].ToString(),
                            Stock = Convert.ToInt32(sdr["Stock"]),
                            Price = Convert.ToDecimal(sdr["Price"]),
                            CategoryId = Convert.ToInt32(sdr["CategoryId"]),
                            ImageUrl = sdr["ImageUrl"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }
            return products; // return the product list which can be used as the datasource for repeater or gridview
        }
        public ProductEntity GetProductById(int id)
        {
            string query = "Select * from Products where ProductId=@id";
            ProductEntity product = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    
                    while (sdr.Read())
                    {
                        product = new ProductEntity
                        {
                            ProductId = Convert.ToInt32(sdr["ProductId"]),
                            Name = sdr["Name"].ToString(),
                            Description = sdr["Description"].ToString(),
                            Stock = Convert.ToInt32(sdr["Stock"]),
                            Price = Convert.ToDecimal(sdr["Price"]),
                            CategoryId = Convert.ToInt32(sdr["CategoryId"]),
                            ImageUrl = sdr["ImageUrl"].ToString()
                        };
                    }
                
                }
            }
            return product; // return the productEntity type 
                           // data can be accessed with dot operator
        }
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            string query = "Select * from Categories";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(query, conn);
                sdr.Fill(dt);
            }
            return dt;
        }

        public void Delete(int pid)
        {
            string query = "Delete from Products where ProductId=@pid";
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStock(int pid, int qty)
        {
            string query = "update Products set Stock=@stock where ProductId=@pid";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@stock", qty);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
