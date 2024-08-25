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
        public bool AddToCart(int Cid, int Uid, int Pid, int qty, decimal unitprice, decimal totalprice )
        {
            int i = obj.Add( Uid, Pid, qty, unitprice, totalprice);
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
