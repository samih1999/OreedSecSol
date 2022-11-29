using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data.Services;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    public class HomeController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public IActionResult Index()
        {
          


            return View(_orderService.GetAll());
        }

        [HttpPost]
        public IActionResult Index(string customername, string location, int ordernumber, DateTime orderdate, Models.Type type, double discount)
        {
            var order = new OrderModel
            {
                Customer = new CustomerModel
                {
                    CustomerName = customername,
                    Location = location,
                }
            ,
                OrderNumber = ordernumber,
                OrderDate = orderdate,
                OrderType = type


            };

            _orderService.SendOrder(order,discount);

            return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
