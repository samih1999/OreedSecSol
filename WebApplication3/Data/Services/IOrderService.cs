using System.Collections;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Data.Services
{
    public interface IOrderService
    {
        public void SendOrder(OrderModel order,double discount);
        public IEnumerable<OrderModel> GetAll();



    }
}
