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
        CartRepository obj = new CartRepository();
        
        public bool AddToCart(int Uid, int Pid, int qty, decimal unitprice, decimal totalprice, string name, string imageurl)
        {
            int i = obj.Create( Uid, Pid, qty, unitprice, totalprice, name, imageurl);
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
            products = obj.Read(Uid);
            return products;
        }
        public bool UpdateCart(int Cid, int qty)
        {
            int i = obj.Update(Cid, qty);
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
            string total = obj.GetTotal(uid);
            return Convert.ToDecimal(total);
        }
        public bool UpdateCartByProductAndUser(int pid, int qty, int uid, decimal totalprice)
        {
            int i = obj.Update(pid, uid, qty, totalprice);
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
            object count = obj.QtyOfId(uid, pid);
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
            int i = obj.Delete(Cid);
            if (i != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
