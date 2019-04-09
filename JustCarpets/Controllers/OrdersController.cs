using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _orderService.GetOrders();
            return View(response.Results);
        }
    }
}