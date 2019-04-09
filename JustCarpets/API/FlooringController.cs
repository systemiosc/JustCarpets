using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustCarpets.API
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FlooringController : ControllerBase
    {
        private IFlooringService _flooringService;
        private ILogger _logger;

        public FlooringController(IFlooringService flooringSevice, ILogger<FlooringController> logger)
        {
            _flooringService = flooringSevice;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetFlooringBySearch(SearchParametersDto search)
        {
            var flooringResponse = await _flooringService.GetFlooring(search);

            if (flooringResponse.Success)
            {
                return Ok(flooringResponse.Results);
            }
            else
            {
                return BadRequest(flooringResponse.FriendlyError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFlooringDetails(int id)
        {
            var response = await _flooringService.GetById(id);

            if (response.Success)
            {
                return Ok(response.Results.FirstOrDefault());
            }
            else
            {
                return BadRequest(response.FriendlyError);
            }
        }
    }
}