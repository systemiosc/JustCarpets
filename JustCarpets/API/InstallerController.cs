using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustCarpets.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallerController : ControllerBase
    {
        private ILogger _logger;
        private IInstallerService _installerService;

        public InstallerController(IInstallerService installerService, ILogger<InstallerController> logger)
        {
            _installerService = installerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetInstallers()
        {
            var response = await _installerService.GetInstallers();
            if (response.Success)
            {
                return Ok(response.Results);
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }
    }
}