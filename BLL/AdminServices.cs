using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using System.Data;

namespace BLL
{
    public class AdminServices
    {
        AdminDataAccess obj = new AdminDataAccess();
        public void DeleteProduct(int pid)
        {
            int i = obj.Delete(pid);
        }
        public DataSet Gridbind()
        {
            DataSet ds = obj.Gridbind_Fun();
            return ds;
        }
        public DataTable GetCategoryItems()
        {
            DataTable ds = obj.GetCategories();
            return ds;
        }
        public void AddProduct(string name , string desc, string price, string stock, string imageurl, string categoryid)
        {
            decimal convertedPrice = Convert.ToDecimal(price);
            int convertedStock = Convert.ToInt32(stock);
            int convertedCategoryid = Convert.ToInt32(categoryid);
            obj.Add(name, desc, convertedPrice, convertedStock, imageurl, convertedCategoryid);
        }
        public void UpdateProduct(string name, string desc, string price, string stock, string imageurl, string categoryid, int pid)
        {
            decimal convertedPrice = Convert.ToDecimal(price);
            int convertedStock = Convert.ToInt32(stock);
            int convertedCategoryid = Convert.ToInt32(categoryid);
            obj.Update(name, desc, convertedPrice, convertedStock, imageurl, convertedCategoryid, pid);
        }
    }
}
