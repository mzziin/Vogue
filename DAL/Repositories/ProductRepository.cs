using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository()
        {
            _connectionString = @"server=DESKTOP-SHCNBA7\SQLEXPRESS;database=Vogue;Integrated Security=true";
        }

        public List<ProductEntity> GetAllProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>(); // list of type ProductEntity
            string query = "Select * from Products";
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

        public ProductEntity GetProductById(int id)
        {
            string query = "Select * from Products where ProductId=@id";
            ProductEntity product = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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
    }
}
