using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.Controllers
{
    public class InstallersController : Controller
    {
        private IInstallerService _installerService;

        public InstallersController(IInstallerService installerService)
        {
            _installerService = installerService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _installerService.GetInstallers();
            return View(response.Results);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _installerService.GetInstallerDetails(id);
            return View(response.Results);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}