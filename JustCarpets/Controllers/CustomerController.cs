using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _customerService.GetCustomers();

            return View(response.Results);
        }
    }
}