using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;
using static System.Environment;

namespace WebApplication3.Data.Services
{


    public class OrderService : IOrderService
    {
     ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderModel> GetAll()
        {

            var order =  _context.orders.Select(order => new OrderModel
            {
                Customer=order.Customer,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                OrderType = order.OrderType,
           

        }).ToList();
            return order;   

        }

        public void SendOrder(OrderModel order, double discount)
        {
            if (order.OrderType==Type.Special)
            {

                var specialorder= new SpeccialOrderModel { 
                    Customer=new CustomerModel { 
                        CustomerName=order.Customer.CustomerName,
                    Location=order.Customer.Location,
                    Orders=order.Customer.Orders
                    
                    },
                    OrderDate=order.OrderDate,
                    OrderNumber=order.OrderNumber,  
                    Discount=discount,
                    OrderType=order.OrderType,
                };
                _context.orders.Add(specialorder);
                _context.customers.Add(specialorder.Customer);
                _context.SaveChanges();
            }

            else
            {
                var normalorder = new NormalOrderModel
                {
                    Customer = new CustomerModel
                    {
                        CustomerName = order.Customer.CustomerName,
                        Location = order.Customer.Location,
                        Orders = order.Customer.Orders

                    },
                    OrderDate = order.OrderDate,
                    OrderNumber=order.OrderNumber,
                    OrderType = order.OrderType,

                    
                };
                _context.orders.Add(normalorder);
                _context.customers.Add(normalorder.Customer);
                _context.SaveChanges();
            }
           
        }
    }
}
