using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Entities;

namespace BLL
{
    public class CartService
    {
        CartDataAccess cartDataAccess = new CartDataAccess();
        
        public bool AddToCart(int Uid, int Pid, int qty, decimal unitprice, decimal totalprice, string name, string imageurl)
        {
            int i = cartDataAccess.Create( Uid, Pid, qty, unitprice, totalprice, name, imageurl);
            if (i != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<CartEntity> ListAllProducts(int Uid)
        {
            List<CartEntity> products;
            products = cartDataAccess.Read(Uid);
            return products;
        }
        public List<CartEntity> ListAllProductsInStock(int Uid)
        {
            List<CartEntity> products;
            products = cartDataAccess.ReadProductsInStock(Uid);
            return products;
        }
        public bool UpdateCart(int Cid, int qty)
        {
            int i = cartDataAccess.Update(Cid, qty);
            if(i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal GetTotalPrice(int uid)
        {
            string total = cartDataAccess.GetTotal(uid);
            decimal result;
            if(decimal.TryParse(total, out result))
            {
                return result;
            }
            else
            {
                return 0.00M;
            }
           
        }
        public bool UpdateCartByProductAndUser(int pid, int qty, int uid, decimal totalprice)
        {
            int i = cartDataAccess.Update(pid, uid, qty, totalprice);
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int QtyOfCartProducts(int uid, int pid)
        {
            object count = cartDataAccess.QtyOfId(uid, pid);
            if(count == null)
            {
                count = "0";
            }
            else
            {
                count = count.ToString();
            }
            return Convert.ToInt32(count);
        }
        //todo
        public bool DeleteFromCart(int Cid)
        {
            int i = cartDataAccess.Delete(Cid);
            if (i != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DeleteFromCartByProductAndUser(int pid, int uid)
        {
            int i = cartDataAccess.Delete(pid, uid);
            if(i != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DeleteFromCartByProduct(int pid)
        {
            int i = cartDataAccess.DeleteByProduct(pid);
            if (i != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteCartOfUser(int uid)
        {
            cartDataAccess.DeleteByUser(uid);
        }
    }
}
