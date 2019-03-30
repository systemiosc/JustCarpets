using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallerAvailabilityController : ControllerBase
    {
        private IInstallerService _installerService;

        public InstallerAvailabilityController(IInstallerService installerService)
        {
            _installerService = installerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetinstallerAvailability(int id)
        {
            var response = await  _installerService.GetInstallerAppointments(id);

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