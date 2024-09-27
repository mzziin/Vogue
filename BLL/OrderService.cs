using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace BLL
{
    public class OrderService
    {
        OrderDataAccess orderDataAccess = new OrderDataAccess();

        public int AddOrder(int uid, string orderDate, decimal totalAmount, string orderStatus, string paymentMethod, string address)
        {
            int orderId = orderDataAccess.AddToOrderTable(uid, orderDate, totalAmount, orderStatus, paymentMethod, address);
            return orderId;
        }
        public void AddOrderDetails(int orderId, int pId, int Qty, int unitPrice, decimal totalPrice)
        {
            orderDataAccess.AddToOrderDetailTable(orderId, pId, Qty, unitPrice, totalPrice);
        }
    }
}
