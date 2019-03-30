using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.Controllers
{
    public class CompanyController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}